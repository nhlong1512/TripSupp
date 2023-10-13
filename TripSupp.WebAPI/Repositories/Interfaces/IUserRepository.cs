using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripSupp.WebAPI.Dtos.ResponseDtos;

namespace TripSupp.WebAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        ValueTask<UserResponse> GetUserByIdAsync(Guid id);
    }
}