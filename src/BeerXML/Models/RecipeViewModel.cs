using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
