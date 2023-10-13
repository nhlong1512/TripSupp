using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripSupp.WebAPI.Dtos.RequestDtos;
using TripSupp.WebAPI.Dtos.ResponseDtos;
using TripSupp.WebAPI.Services.Interfaces;

namespace TripSupp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtTokenService _jwtTokenService;
        public AuthController(IAuthService authService, IJwtTokenService jwtTokenService)
        {
            _authService = authService;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("register")]
        public async ValueTask<IActionResult> Register([FromForm] RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RegisterResponse registerResponse = await _authService.RegisterAsync(registerRequest);
            return Ok(registerResponse);
        }

        [HttpPost("login")]
        public async ValueTask<IActionResult> Login([FromForm] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LoginResponse loginResponse = await _authService.LoginAsync(loginRequest);
            if (loginResponse == null)
            {
                return Unauthorized();
            }
            return Ok(loginResponse);
        }
    }
}