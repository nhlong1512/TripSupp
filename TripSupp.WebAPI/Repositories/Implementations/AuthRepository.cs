using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TripSupp.WebAPI.Data;
using TripSupp.WebAPI.Dtos.RequestDtos;
using TripSupp.WebAPI.Dtos.ResponseDtos;
using TripSupp.WebAPI.Models;
using TripSupp.WebAPI.Repositories.Interfaces;
using TripSupp.WebAPI.Services.Interfaces;

namespace TripSupp.WebAPI.Repositories.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IJwtTokenService _jwtTokenService;
        public AuthRepository(DataContext context, IJwtTokenService jwtTokenService)
        {
            _context = context;
            _jwtTokenService = jwtTokenService;
        }
        public async ValueTask<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginRequest.Email);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(loginRequest.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            Token token = await _jwtTokenService.GenerateTokenAsync(user);
            LoginResponse loginResponse = new LoginResponse
            {
                Token = token.AccessToken,
            };
            return loginResponse;
        }

        public async ValueTask<RegisterResponse> RegisterAsync(RegisterRequest registerRequest)
        {
            CreatePasswordHashAsync(registerRequest.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new User
            {
                Id = Guid.NewGuid(),
                Email = registerRequest.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                FullName = registerRequest.FullName,
                Role = "USER"
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            Token token = await _jwtTokenService.GenerateTokenAsync(user);
            RegisterResponse registerResponse = new RegisterResponse
            {
                Token = token.AccessToken,
            };
            return registerResponse;

        }

        public async ValueTask<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);
        }


        private void CreatePasswordHashAsync(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                passwordSalt = hmac.Key;
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}