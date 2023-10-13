using System;
using System.Collections.Generic;
using System.Linq;
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
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password);

            if (user == null)
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
            User user = new User
            {
                Id = Guid.NewGuid(),
                Email = registerRequest.Email,
                Password = registerRequest.Password,
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
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}