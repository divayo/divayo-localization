using System.Collections.Generic;
using System.Threading.Tasks;
using Divayo.Localization.Common;
using Divayo.Localization.Common.Dto;

namespace Divayo.Localization.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<CountryDto>> GetAllCountriesAsync();
        Task<CountryDto> GetCountryByIdAsync(long countryId, RetrieveOptions options);
        Task<IEnumerable<LanguageDto>> GetLanguagesAsync();
    }
}