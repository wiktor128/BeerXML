﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BeerXML.Models
{
    public class RecipeViewModel
    {
        public Recipe Recipe { get; set; }
        public Water Water { get; set; }
        public Hop Hop { get; set; }
        public Fermentable Fermentable { get; set; }
        public Yeast Yeast { get; set; }
        public Misc Misc { get; set; }
        public Equipment Equipment { get; set; }
        public Style Style { get; set; }
        public Mash Mash { get; set; }
        public List<MashStep> MashSteps { get; set; }
    }
}
