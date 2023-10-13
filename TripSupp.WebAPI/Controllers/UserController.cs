using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripSupp.WebAPI.Dtos.ResponseDtos;
using TripSupp.WebAPI.Services.Interfaces;

namespace TripSupp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetUserById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserResponse userResponse = await _userService.GetUserByIdAsync(id);
            return Ok(userResponse);
        }
    }
}