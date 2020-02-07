using Divayo.Localization.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Divayo.Localization.Data.Entities
{
    public class CountryArea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public CountryAreaType CountryAreaType { get; set; }

        [Required]
        [ForeignKey("Country")]
        public long CountryId { get; set; }

        public long? ParentCountryAreaId { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }

        public virtual Country Country { get; set; }
        public virtual CountryArea ParentCountryArea { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<CityArea> CityAreas { get; set; }
        public virtual ICollection<CountryArea> CountryAreas { get; set; }
    }
}
