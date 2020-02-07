using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Divayo.Localization.Data.Entities
{
    public class CityAreaCity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [ForeignKey("CityArea")]
        public long CityAreaId { get; set; }

        [Required]
        [ForeignKey("City")]
        public long CityId { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }

        public virtual City City { get; set; }
        public virtual CityArea CityArea { get; set; }
    }
}
