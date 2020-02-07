using Divayo.Localization.Common;
using Divayo.Localization.Common.Dto;
using Divayo.Localization.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divayo.Localization.Services
{
    public class SearchService
    {
        private readonly LocalizationDbContext _dbContext;
        private readonly ICachingService _cachingService;

        public SearchService(LocalizationDbContext dbContext, ICachingService cachingService)
        {
            _dbContext = dbContext;
            _cachingService = cachingService;
        }

        public async Task<CountryDto> GetCountryByIdAsync(long countryId, RetrieveOptions options)
        {
            var countries = await _cachingService.GetCountriesAsync();
            var country = countries.FirstOrDefault(c => c.Id == countryId);

            if (options.IncludeCountryAreas)
            {
                country.CountryAreas = await GetCountryAreasForCountryAsync(countryId);
            }

            return country;
        }

        private async Task<IEnumerable<CountryAreaDto>> GetCountryAreasForCountryAsync(long countryId)
        {
            var countryAreas = await _cachingService.GetCountryAreasAsync();

            return countryAreas.Where(c => c.CountryId == countryId);
        }
    }
}
