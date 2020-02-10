using AutoMapper;
using Divayo.Localization.Common.Dto;
using Divayo.Localization.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Divayo.Localization.Services
{
    public class CachingService : ICachingService
    {
        private readonly LocalizationDbContext _dbContext;
        private IMemoryCache _cache;
        private IMapper _mapper;

        public CachingService(LocalizationDbContext dbContext, IMemoryCache memoryCache, IMapper mapper)
        {
            _dbContext = dbContext;
            _cache = memoryCache;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryDto>> GetCountriesAsync()
        {
            var cacheKey = "GetCountriesAsync";
            IEnumerable<CountryDto> dtos;

            if (_cache.TryGetValue(cacheKey, out dtos))
            {
                return dtos;
            }
            else
            {
                var dbResult = await _dbContext.Countries.ToListAsync();
                dtos = _mapper.Map<IEnumerable<CountryDto>>(dbResult);

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetAbsoluteExpiration(DateTime.UtcNow.AddDays(1));

                // Save data in cache.
                _cache.Set(cacheKey, dtos, cacheEntryOptions);

                return dtos;
            }
        }

        public async Task<IEnumerable<CountryAreaDto>> GetCountryAreasAsync()
        {
            var cacheKey = "GetCountryAreasAsync";
            IEnumerable<CountryAreaDto> dtos;

            if (_cache.TryGetValue(cacheKey, out dtos))
            {
                return dtos;
            }
            else
            {
                var dbResult = await _dbContext.CountryAreas.ToListAsync();
                dtos = _mapper.Map<IEnumerable<CountryAreaDto>>(dbResult);

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetAbsoluteExpiration(DateTime.UtcNow.AddDays(1));

                // Save data in cache.
                _cache.Set(cacheKey, dtos, cacheEntryOptions);

                return dtos;
            }
        }

        public async Task<IEnumerable<LanguageDto>> GetLanguagesAsync()
        {
            var cacheKey = "GetLanguagesAsync";
            IEnumerable<LanguageDto> dtos;

            if (_cache.TryGetValue(cacheKey, out dtos))
            {
                return dtos;
            }
            else
            {
                var dbResult = await _dbContext.Languages.ToListAsync();
                dtos = _mapper.Map<IEnumerable<LanguageDto>>(dbResult);

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetAbsoluteExpiration(DateTime.UtcNow.AddDays(1));

                // Save data in cache.
                _cache.Set(cacheKey, dtos, cacheEntryOptions);

                return dtos;
            }
        }
    }
}
