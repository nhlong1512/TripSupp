using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripSupp.WebAPI.Dtos.RequestDtos;
using TripSupp.WebAPI.Dtos.ResponseDtos;
using TripSupp.WebAPI.Repositories.Interfaces;
using TripSupp.WebAPI.Services.Interfaces;

namespace TripSupp.WebAPI.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async ValueTask<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = await _authRepository.LoginAsync(loginRequest);
            return loginResponse;
        }

        public async ValueTask<RegisterResponse> RegisterAsync(RegisterRequest registerRequest)
        {
            bool isUserExisted = await _authRepository.UserExists(registerRequest.Email);
            if (isUserExisted)
            {
                throw new Exception("User with this email already exists");
            }

            RegisterResponse registerResponse = await _authRepository.RegisterAsync(registerRequest);
            return registerResponse;
        }

    }
}