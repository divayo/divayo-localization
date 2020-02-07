using System;
using System.Collections.Generic;
using System.Text;

namespace Divayo.Localization.Common.Dto
{
    public class CountryDto
    {
        public long Id { get; set; }
        
        public string Name { get; set; }

        public string Alpha2Code { get; set; }
        
        public string Alpha3Code { get; set; }

        public string NumericCode { get; set; }
        
        public IEnumerable<CountryAreaDto> CountryAreas { get; set; }
    }
}
