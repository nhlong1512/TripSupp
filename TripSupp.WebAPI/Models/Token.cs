using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripSupp.WebAPI.Models
{
    public class Token
    {
        public string AccessToken { get; set; }
        // public string RefreshToken { get; set; }
        public DateTime Expires { get; set; }
    }
}