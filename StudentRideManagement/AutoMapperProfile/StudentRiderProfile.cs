using AutoMapper;
using StudentRideManagement.DTO;
using StudentRideManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.AutoMapperProfile
{
    public class StudentRiderProfile : Profile
    {
        public StudentRiderProfile()
        {
            CreateMap<RiderDTO, Rider>();
            CreateMap<RegisterUserDTO, RegisterUser>();
            CreateMap<StudentDTO, Student>();
            CreateMap<StudentUpdateDTO, Student>();
            CreateMap<StudentRideDTO, StudentRide>();
        }
    }
}
