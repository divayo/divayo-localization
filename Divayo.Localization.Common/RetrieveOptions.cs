using System;
using System.Collections.Generic;
using System.Text;

namespace Divayo.Localization.Common
{
    public class RetrieveOptions
    { 
        public bool IncludeCountryAreas { get; set; }
        public bool IncludeCities { get; set; }
        public bool IncludeCityAreas { get; set; }
        public bool IncludeLanguages { get; set; }
    }
}
