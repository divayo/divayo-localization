using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divayo.Localization.Common.Dto
{
    public class CountryInfoDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("alpha-2")]
        public string Alpha2 { get; set; }

        [JsonProperty("alpha-3")]
        public string Alpha3 { get; set; }

        [JsonProperty("country-code")]
        public string CountryCode { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("region-code")]
        public string RegionCode { get; set; }

        [JsonProperty("sub-region")]
        public string SubRegion { get; set; }

        [JsonProperty("sub-region-code")]
        public string SubRegionCode { get; set; }
    }
}
