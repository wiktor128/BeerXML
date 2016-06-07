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
    public class Misc
    {
        [XmlIgnore]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MiscId { get; set; }

        [XmlElement("NAME")]
        [Required]
        public string Name { get; set; }

        [XmlElement("VARSION")]
        [Required]
        public double Version { get; set; }

        [XmlElement("TYPE")]
        [Required]
        public string Type { get; set; }

        [XmlElement("USE")]
        [Required]
        public string Use { get; set; }

        [XmlElement("TIME")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double Time { get; set; }

        [XmlElement("AMOUNT")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double Amount { get; set; }

        [XmlIgnore]
        [Display(Name = "Amount Is Weight")]
        public bool AmountIsWeight { get; set; }

        [XmlElement("AMOUNT_IS_WEIGHT")]
        [NotMapped]
        [ScaffoldColumn(false)]
        public string AmountIsWeightAsString
        {
            get
            {
                return XmlConvert.ToString(AmountIsWeight);
            }

            set
            {
                bool ParsedValue;

                if (!Boolean.TryParse(value, out ParsedValue))
                    ParsedValue = XmlConvert.ToBoolean(value);

                AmountIsWeight = ParsedValue;
            }
        }

        [XmlElement("USE_FOR")]
        [Display(Name = "Use For")]
        public string UseFor { get; set; }

        [XmlElement("NOTES")]
        public string Notes { get; set; }

        [XmlIgnore]
        public List<MiscRecipe> MiscRecipe { get; set; }
    }

    public class MiscRecipe
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int MiscId { get; set; }
        public Misc Misc { get; set; }
    }
}
