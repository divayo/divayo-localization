﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Divayo.Localization.Common.Dto
{
    public class LanguageDto
    {
        public long Id { get; set; }

        public string ShortName { get; set; }

        public string Name { get; set; }

        public string NativeName { get; set; }
    }
}
