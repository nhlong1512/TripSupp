using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripSupp.WebAPI.Dtos.RequestDtos;
using TripSupp.WebAPI.Dtos.ResponseDtos;

namespace TripSupp.WebAPI.Services.Interfaces
{
    public interface IAuthService
    {
        ValueTask<LoginResponse> LoginAsync(LoginRequest loginRequest);
        ValueTask<RegisterResponse> RegisterAsync(RegisterRequest registerRequest);
    }
}