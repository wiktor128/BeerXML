using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;


namespace BeerXML.Models
{
    public class Hop
    {
        [XmlIgnore]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HopId { get; set; }

        [XmlElement("NAME")]
        [Required]
        public string Name { get; set; }

        [XmlElement("VERSION")]
        [Required]
        public double Version { get; set; }

        [XmlElement("ALPHA")]
        [Required]
        [Range(0, 100)]
        public double Alpha { get; set; }

        [XmlElement("AMOUNT")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double Amount { get; set; }

        [XmlElement("USE")]
        [Required]
        public string Use { get; set; }

        [XmlElement("TIME")]
        [Required]
        public double Time { get; set; }

        [XmlElement("NOTES")]
        public string Notes { get; set; }

        [XmlElement("TYPE")]
        public string Type { get; set; }

        [XmlElement("FORM")]
        public string Form { get; set; }

        [XmlElement("BETA")]
        [Range(0, 100)]
        public double Beta { get; set; }

        [XmlElement("HSI")]
        [Range(0, 100)]
        public double HSI { get; set; }

        [XmlElement("ORIGIN")]
        public string Origin { get; set; }

        [XmlElement("SUBSTITUTES")]
        public string Substitutes { get; set; }

        [XmlElement("HUMULENE")]
        [Range(0, 100)]
        public double Humulene { get; set; }

        [XmlElement("CARYOPHYLLENE")]
        [Range(0, 100)]
        public double Caryophyllene { get; set; }

        [XmlElement("COHUMULONE")]
        [Range(0, 100)]
        public double Cohumulone { get; set; }

        [XmlElement("MYRCENE")]
        [Range(0, 100)]
        public double Myrcene { get; set; }

        [XmlIgnore]
        public List<HopRecipe> HopRecipe { get; set; }

    }

    public class HopRecipe
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int HopId { get; set; }
        public Hop Hop { get; set; }
    }
}
