using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using System.Xml;

namespace BeerXML.Models
{
    public class Mash
    {
        [XmlIgnore]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MashId { get; set; }

        [XmlElement("NAME")]
        [Required]
        public string Name { get; set; }

        [XmlElement("VERSION")]
        [Required]
        public double Version { get; set; }

        [XmlElement("GRAIN_TEMP")]
        [Required]
        [Display(Name = "Grain Temp")]
        public double GrainTemp { get; set; }

        [Required]
        public virtual List<MashStepMash> MashStepMash { get; set; }
        [XmlArray("MASH_STEPS")]
        [XmlArrayItem("MASH_STEP")]
        public List<MashStep> MashSteps = new List<MashStep>();

        [XmlElement("NOTES")]
        public string Notes { get; set; }

        [XmlElement("TUN_TEMP")]
        [Display(Name = "Tun Temp")]
        public double TunTemp { get; set; }

        [XmlElement("SPARGE_TEMP")]
        [Display(Name = "Sparge Temp")]
        public double SpargeTemp { get; set; }

        [XmlElement("PH")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double Ph { get; set; }

        [XmlElement("TUN_WEIGHT")]
        [Display(Name = "Tun Weight")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double TunWeight { get; set; }

        [XmlElement("TUN_SPECIFIC_HEAT")]
        [Display(Name = "Tun Specific Heat")]
        public double TunspecificHeat { get; set; }

        [XmlIgnore]
        [Display(Name = "Equip Adjust")]
        public bool EquipAdjust { get; set; }

        [XmlElement("EQUIP_ADJUST")]
        [NotMapped]
        [ScaffoldColumn(false)]
        public string EquipAdjustAsString
        {
            get
            {
                return XmlConvert.ToString(EquipAdjust);
            }

            set
            {
                bool ParsedValue;

                if (!Boolean.TryParse(value, out ParsedValue))
                    ParsedValue = XmlConvert.ToBoolean(value);

                EquipAdjust = ParsedValue;
            }
        }

        [XmlIgnore]
        public List<MashRecipe> MashRecipe { get; set; }
    }

    public class MashRecipe
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int MashId { get; set; }
        public Mash Mash { get; set; }
    }
}
