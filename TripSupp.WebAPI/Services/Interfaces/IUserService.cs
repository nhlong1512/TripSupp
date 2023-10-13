using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripSupp.WebAPI.Dtos.ResponseDtos;

namespace TripSupp.WebAPI.Services.Interfaces
{
    public interface IUserService
    {
        ValueTask<UserResponse> GetUserByIdAsync(Guid id);
    }
}