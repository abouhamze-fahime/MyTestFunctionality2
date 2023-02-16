using Application.Dto;
using AutoMapper;
using Domain.Models.UserModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, PersonDto>().ReverseMap();


        }
    }
}
