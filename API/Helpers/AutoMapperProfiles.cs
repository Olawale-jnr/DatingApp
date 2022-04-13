﻿using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Map from source to destination, source is AppUser, Destination is the Dto..
            //For member, Mapping from source and assigning to destination
            CreateMap<AppUser, MemberDto>().ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => 
                src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth
                .CalculateAge()));

            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
        }
    }
}
