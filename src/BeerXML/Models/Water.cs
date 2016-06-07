using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BeerXML.Models
{
    public class Water
    {
        [XmlIgnore]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WaterId { get; set; }

        [XmlElement("NAME")]
        [Required]
        public string Name { get; set; }

        [XmlElement("VERSION")]
        [Required]
        public int Version { get; set; }

        [XmlElement("AMOUNT")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double Amount { get; set; }

        [XmlElement("CALCIUM")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double Calcium { get; set; }

        [XmlElement("BICARBONATE")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double Bicarbonate { get; set; }

        [XmlElement("SULFATE")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double Sulfate { get; set; }

        [XmlElement("CHLORIDE")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double Chloride { get; set; }

        [XmlElement("SODIUM")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double Sodium { get; set; }

        [XmlElement("MAGNESIUM")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double Magnesium { get; set; }

        [XmlElement("PH")]
        [Range(0, 14, ErrorMessage = "The value must be in range [0,14]")]
        public double Ph { get; set; }

        [XmlElement("NOTES")]
        public String Notes { get; set; }

        [XmlIgnore]
        public List<WaterRecipe> WaterRecipe { get; set; }
    }
    
    public class WaterRecipe
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int WaterId { get; set; }
        public Water Water { get; set; }
    }
}
