using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Divayo.Localization.Data.Entities
{
    public class CountryLanguage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [ForeignKey("Country")]
        public long CountryId { get; set; }

        [Required]
        [ForeignKey("Language")]
        public long LanguageId { get; set; }

        public bool IsOfficialLanguage { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }

        public virtual Country Country { get; set; }
        public virtual Language Language { get; set; }
    }
}
