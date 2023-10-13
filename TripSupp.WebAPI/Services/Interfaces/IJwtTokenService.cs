using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripSupp.WebAPI.Models;

namespace TripSupp.WebAPI.Services.Interfaces
{
    public interface IJwtTokenService
    {
        ValueTask<Token> GenerateTokenAsync(User user);
    }
}