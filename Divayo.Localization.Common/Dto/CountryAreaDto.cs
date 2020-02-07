using System;
using System.Collections.Generic;
using System.Text;

namespace Divayo.Localization.Common.Dto
{
    public class CountryAreaDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long CountryId { get; set; }
    }
}
