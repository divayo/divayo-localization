using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Divayo.Localization.Data.Entities
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(2, MinimumLength = 2)]
        public string Alpha2Code { get; set; }

        [StringLength(3, MinimumLength = 3)]
        public string Alpha3Code { get; set; }

        [StringLength(4, MinimumLength = 3)]
        public string NumericCode { get; set; }

        public bool IsIndependent { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<CityArea> CityAreas { get; set; }
        public virtual ICollection<CountryArea> CountryAreas { get; set; }
        public virtual ICollection<CountryLanguage> CountryLanguages { get; set; }
    }
}
