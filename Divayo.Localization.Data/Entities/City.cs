using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Divayo.Localization.Data.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Country")]
        public long CountryId { get; set; }

        [ForeignKey("CountryAreaId")]
        public long CountryAreaId { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }

        public virtual Country Country { get; set; }
        public virtual CountryArea CountryArea { get; set; }

        public virtual ICollection<CityAreaCity> CityAreaCities { get; set; }
    }
}
