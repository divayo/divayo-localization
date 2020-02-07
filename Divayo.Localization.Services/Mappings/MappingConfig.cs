using AutoMapper;
using Divayo.Localization.Common.Dto;
using Divayo.Localization.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Divayo.Localization.Services.Mappings
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Country, CountryDto>();                
        }
    }
}
