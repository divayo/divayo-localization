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
            CreateMap<CountryArea, CountryAreaDto>();
            CreateMap<Language, LanguageDto>();

            CreateMap<CountryInfoDto, Country>()
                .ForMember(d => d.Alpha2Code, opts => opts.MapFrom(src => src.Alpha2))
                .ForMember(d => d.Alpha3Code, opts => opts.MapFrom(src => src.Alpha3));
        }
    }
}
