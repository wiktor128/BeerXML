using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerXML.Models
{
    public class MashMashStepViewModel
    {
        public Mash Mash { get; set; }
        public List<MashStep> MashSteps { get; set; }
    }
}
