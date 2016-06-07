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
    public class Yeast
    {
        [XmlIgnore]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YeastId { get; set; }

        [XmlElement("NAME")]
        [Required]
        public string Name { get; set; }

        [XmlElement("VERSION")]
        [Required]
        public int Version { get; set; }

        [XmlElement("TYPE")]
        [Required]
        public string Type { get; set; }

        [XmlElement("FORM")]
        [Required]
        public string Form { get; set; }

        [XmlElement("AMOUNT")]
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float Amount { get; set; }

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

        [XmlElement("LABORATORY")]
        public string Laboratory { get; set; }

        [XmlElement("PRODUCT_ID")]
        [Display(Name = "Product ID")]
        public string ProductID { get; set; }

        [XmlElement("MIN_TEMPERATURE")]
        [Display(Name = "Min Temperature")]
        public float MinTemperature { get; set; }

        [XmlElement("MAX_TEMPERATURE")]
        [Display(Name = "Max Temperature")]
        public float MaxTemperature { get; set; }

        [XmlElement("FLOCCULATION")]
        public string Flocculation { get; set; }

        [XmlElement("ATTENUATION")]
        [Range(0,100)]
        public float Attenuation { get; set; }

        [XmlElement("NOTES")]
        public string Notes { get; set; }

        [XmlElement("BEST_FOR")]
        [Display(Name = "Best For")]
        public string BestFor { get; set; }

        [XmlElement("TIMES_CULTURED")]
        [Display(Name = "Times Cultured")]
        [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int TimesCultured { get; set; }

        [XmlElement("MAX_REUSE")]
        [Display(Name = "Max Reuse")]
        [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int MaxReuse { get; set; }
    
        [XmlIgnore]
        [Display(Name = "Add To Secondary")]
        public bool AddToSecondary { get; set; }

        [XmlElement("ADD_TO_SECONDARY")]
        [NotMapped]
        [ScaffoldColumn(false)]
        public string AddToSecondaryAsString
        {
            get
            {
                return XmlConvert.ToString(AddToSecondary);
            }

            set
            {
                bool ParsedValue;

                if (!Boolean.TryParse(value, out ParsedValue))
                    ParsedValue = XmlConvert.ToBoolean(value);

                AddToSecondary = ParsedValue;
            }
        }

        [XmlIgnore]
        public List<YeastRecipe> YeastRecipe { get; set; }
    }

    public class YeastRecipe
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int YeastId { get; set; }
        public Yeast Yeast { get; set; }
    }
}
