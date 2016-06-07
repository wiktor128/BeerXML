using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BeerXML.Models
{
    public class MashStep
    {
        [XmlIgnore]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MashStepId { get; set; }

        [XmlElement("NAME")]
        [Required]
        public string Name { get; set; }

        [XmlElement("VERSION")]
        [Required]
        public double Version { get; set; }

        [XmlElement("TYPE")]
        [Required]
        public string Type { get; set;}

        [XmlElement("INFUSE_AMOUNT")]
        [Display(Name = "Infuse Amount")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double InfuseAmount { get; set; }

        [XmlElement("STEP_TEMP")]
        [Required]
        [Display(Name = "Step Temp")]
        public double StepTemp { get; set; }

        [XmlElement("STEP_TIME")]
        [Required]
        [Display(Name = "Step Time")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double StepTime { get; set; }

        [XmlElement("RAMP_TIME")]
        [Display(Name = "Ramp Time")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double RampTime { get; set; }

        [XmlElement("END_TEMP")]
        [Display(Name = "End Temp")]
        public double EndTemp { get; set; }

        [XmlIgnore]
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
