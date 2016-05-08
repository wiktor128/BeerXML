using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerXML.Models
{
    public class MashStep
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MashStepId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Version { get; set; }

        [Required]
        public string Type { get; set;}

        [Display(Name = "Infuse Amount")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float InfuseAmount { get; set; }

        [Required]
        [Display(Name = "Step Temp")]
        public float StepTemp { get; set; }

        [Required]
        [Display(Name = "Step Time")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float StepTime { get; set; }

        [Display(Name = "Ramp Time")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float RampTime { get; set; }

        [Display(Name = "End Temp")]
        public float EndTemp { get; set; }

        public List<MashStepMash> MashStepMash { get; set; }
    }

    public class MashStepMash
    {
        public int MashId { get; set; }
        public Mash Mash { get; set; }

        public int MashStepId { get; set; }
        public MashStep MashStep { get; set; }
    }
}
