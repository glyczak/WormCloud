using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WormCloud.Dtos;
using WormCloud.Models;

namespace WormCloud.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Strain, StrainDto>();
            Mapper.CreateMap<StrainDto, Strain>();
        }
    }
}