using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripSupp.WebAPI.Dtos.RequestDtos
{
    public class RegisterRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}