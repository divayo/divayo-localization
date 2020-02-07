using System;

namespace Divayo.Localization.Data.Repositories
{
    public class CountryRepository
    {
        private readonly LocalizationDbContext _dbContext;

        public CountryRepository(LocalizationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
