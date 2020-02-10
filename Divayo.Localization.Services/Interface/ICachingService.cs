using Divayo.Localization.Common.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Divayo.Localization.Services
{
    public interface ICachingService
    {
        Task<IEnumerable<CountryDto>> GetCountriesAsync();

        Task<IEnumerable<CountryAreaDto>> GetCountryAreasAsync();

        Task<IEnumerable<LanguageDto>> GetLanguagesAsync();
    }
}