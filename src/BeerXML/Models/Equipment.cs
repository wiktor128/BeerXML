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
    public class Equipment
    {
        [XmlIgnore]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipmentId { get; set; }

        [XmlElement("NAME")]
        [Required]
        public string Name { get; set; }

        [XmlElement("VERSION")]
        [Required]
        public double Version { get; set; }

        [XmlElement("BOIL_SIZE")]
        [Display(Name = "Boil Size")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Required]
        public double BoilSize { get; set; }

        [XmlElement("BATCH_SIZE")]
        [Display(Name = "Batch Size")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double BatchSize { get; set; }

        [XmlElement("TUN_VOLUME")]
        [Display(Name = "Tun Volume")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double TunVolume { get; set; }

        [XmlElement("TUN_WEIGHT")]
        [Display(Name = "Tun Weight")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double TunWeight { get; set; }

        [XmlElement("TUN_SPECIFIC_HEAT")]
        [Display(Name = "Tun Specific Heat")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double TunSpecificHeat { get; set; }

        [XmlElement("TOP_UP_WATER")]
        [Display(Name = "Top Up Water")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double TopUpWater { get; set; }

        [XmlElement("TRUB_CHILLER_LOSS")]
        [Display(Name = "Trub Chiller Loss")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double TrubChillerLoss { get; set; }

        [XmlElement("EVAP_RATE")]
        [Display(Name = "Evap Rate")]
        [Range(0, 100)]
        public double EvapRate { get; set; }

        [XmlElement("BOIL_TIME")]
        [Display(Name = "Boil Time")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double BoilTime { get; set; }

        [XmlIgnore]
        [Display(Name = "Calc Boil Volume")]
        public bool CalcBoilVolume { get; set; }

        [XmlElement("CALC_BOIL_VOLUME")]
        [ScaffoldColumn(false)]
        [NotMapped]
        public string CalcBoilVolumeAsString
        {
            get
            {
                return XmlConvert.ToString(CalcBoilVolume);
            }

            set
            {
                bool ParsedValue;

                if (!Boolean.TryParse(value, out ParsedValue))
                    ParsedValue = XmlConvert.ToBoolean(value);

                CalcBoilVolume = ParsedValue;
            }
        }

        [XmlElement("LAUTER_DEADSPACE")]
        [Display(Name = "Lauter Deadspace")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double LauterDeadspace { get; set; }

        [XmlElement("TOP_UP_KETTLE")]
        [Display(Name = "Top Up Kettle")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double TopUpKettle { get; set; }

        [XmlElement("HOP_UTILIZATION")]
        [Display(Name = "Hop Utilization")]
        [Range(0, 100)]
        public double HopUtilization { get; set; }

        [XmlElement("NOTES")]
        public string Notes { get; set; }

        [XmlIgnore]
        public List<EquipmentRecipe> EquipmentRecipe { get; set; }
    }

    public class EquipmentRecipe
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment{ get; set; }
    }
}
