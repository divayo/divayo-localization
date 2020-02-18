using AutoMapper;
using Divayo.Localization.Common.Dto;
using Divayo.Localization.Data;
using Divayo.Localization.Data.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divayo.Localization.Services
{
    public class DataGeneratorService
    {
        public static async Task AddSeedDataAsync(IServiceScope scope)
        {
            var mapper = scope.ServiceProvider.GetService<IMapper>();

            using (var dbContext = scope.ServiceProvider.GetService<LocalizationDbContext>())
            {
                await AddCountriesFromJsonAsync(dbContext, mapper);
                await AddLanguagesFromJsonAsync(dbContext, mapper);
            }
        }

        private static async Task AddCountriesFromJsonAsync(LocalizationDbContext dbContext, IMapper mapper)
        {
            var rootFolder = Directory.GetCurrentDirectory();
            var dataFile = "Assets/countries.json";
            var filePath = $"{rootFolder}/{dataFile}";

            if (dbContext.Countries.Any())
            {
                return;
            }

            if (!File.Exists(filePath))
            {
                throw new ArgumentException("Invalid data file path");
            }

            var json = await File.ReadAllTextAsync(filePath);

            List<CountryInfoDto> dtos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CountryInfoDto>>(json);

            var mappedEntities = mapper.Map<List<Country>>(dtos);

            await dbContext.AddRangeAsync(mappedEntities);
            await dbContext.SaveChangesAsync();



        }

        private static async Task AddLanguagesFromJsonAsync(LocalizationDbContext dbContext, IMapper mapper)
        {
            var rootFolder = Directory.GetCurrentDirectory();
            var dataFile = "Assets/languages.json";
            var filePath = $"{rootFolder}/{dataFile}";

            if (dbContext.Countries.Any())
            {
                return;
            }

            if (!File.Exists(filePath))
            {
                throw new ArgumentException("Invalid data file path");
            }

            var json = await File.ReadAllTextAsync(filePath);

            List<LanguageInfoDto> dtos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LanguageInfoDto>>(json);

            var mappedEntities = mapper.Map<List<Language>>(dtos);

            await dbContext.AddRangeAsync(mappedEntities);
            await dbContext.SaveChangesAsync();

        }
    }
}
