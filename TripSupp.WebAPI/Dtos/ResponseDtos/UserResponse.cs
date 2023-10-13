using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripSupp.WebAPI.Dtos.ResponseDtos
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}