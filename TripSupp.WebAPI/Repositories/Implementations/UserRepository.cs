using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TripSupp.WebAPI.Data;
using TripSupp.WebAPI.Dtos.ResponseDtos;
using TripSupp.WebAPI.Models;
using TripSupp.WebAPI.Repositories.Interfaces;

namespace TripSupp.WebAPI.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async ValueTask<UserResponse> GetUserByIdAsync(Guid id)
        {
            User user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            UserResponse userResponse = _mapper.Map<UserResponse>(user);
            return userResponse;
        }
    }
}