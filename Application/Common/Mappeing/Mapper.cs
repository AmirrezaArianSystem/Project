using Application.Commands;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.Internal;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappeing
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<City, CityDto>().ReverseMap();
            //CreateMap<List<City>,List<CityDto>>().ReverseMap();
            CreateMap<Province, ProvinceDto>().ReverseMap();
            CreateMap<ProvinceCreateCommand,Province>().ForMember(dest => dest.Id, otp => otp.MapFrom(src => SetGuid())).
                ForMember(dest => dest.Name, otp => otp.MapFrom(src => RemoveWhitSpace(src.Name)));
            CreateMap<CityCreateCommand,City>().ForMember(dest=>dest.Id,otp=>otp.MapFrom(src=> SetGuid())).
                ForMember(dest => dest.Name, otp =>otp.MapFrom(src=> RemoveWhitSpace(src.Name)));
            CreateMap<ProvinceUpdateCommand, Province>().ReverseMap();

        }

        private string RemoveWhitSpace(string name)
        {
            return name.Trim();
        }

        private Guid SetGuid()
        {
            return Guid.NewGuid();
        }
    }
}
