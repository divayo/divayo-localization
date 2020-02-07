using Divayo.Localization.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Divayo.Localization.Data
{
    public class LocalizationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // CountryArea self reference
            modelBuilder.Entity<CountryArea>()
                        .HasOne(c => c.ParentCountryArea)
                        .WithOne()
                        .HasForeignKey<CountryArea>(c => c.ParentCountryAreaId)
                        .OnDelete(DeleteBehavior.Restrict);
        }

        #region dbsets
        public DbSet<City> Cities { get; set; }
        public DbSet<CityArea> CityAreas { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryArea> CountryAreas { get; set; }
        public DbSet<Language> Languages { get; set; }
        #endregion
    }
}
