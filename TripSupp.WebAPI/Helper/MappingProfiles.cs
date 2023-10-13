using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TripSupp.WebAPI.Models;
using TripSupp.WebAPI.Dtos.RequestDtos;
using TripSupp.WebAPI.Dtos.ResponseDtos;

namespace TripSupp.WebAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<DestinationRequest, Destination>().ReverseMap();
            CreateMap<User, UserResponse>();
        }
    }
}