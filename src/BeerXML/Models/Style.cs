using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BeerXML.Models
{
    public class Style
    {
        [XmlIgnore]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StyleId { get; set; }

        [XmlElement("NAME")]
        [Required]
        public string Name { get; set; }

        [XmlElement("CATEGORY")]
        [Required]
        public string Category { get; set; }

        [XmlElement("VERSION")]
        [Required]
        public int Version { get; set; }

        [XmlElement("CATEGORY_NUMBER")]
        [Required]
        [Display(Name = "Category Number")]
        public string CategoryNumber { get; set; }

        [XmlElement("STYLE_LETTER")]
        [Required]
        [Display(Name = "Style Letter")]
        public string StyleLetter { get; set; }

        [XmlElement("STYLE_GUIDE")]
        [Required]
        [Display(Name = "Style Guide")]
        public string StyleGuide { get; set; }

        [XmlElement("TYPE")]
        [Required]
        public string Type { get; set; }

        [XmlElement("OG_MIN")]
        [Required]
        [Display(Name = "OG Min")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double OgMin { get; set; }

        [XmlElement("OG_MAX")]
        [Required]
        [Display(Name = "OG Max")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double OgMax { get; set; }

        [XmlElement("FG_MIN")]
        [Required]
        [Display(Name = "FG Min")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double FgMin { get; set; }

        [XmlElement("FG_MAX")]
        [Required]
        [Display(Name = "FG Max")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double FgMax { get; set; }

        [XmlElement("IBU_MIN")]
        [Required]
        [Display(Name = "IBU Min")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double IbuMin { get; set; }

        [XmlElement("IBU_MAX")]
        [Required]
        [Display(Name = "IBU Max")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double IbuMax { get; set; }

        [XmlElement("COLOR_MAX")]
        [Required]
        [Display(Name = "Color Max")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double ColorMin { get; set; }

        [XmlElement("COLOR_MIN")]
        [Required]
        [Display(Name = "Color Min")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double ColorMax { get; set; }

        [XmlElement("CARB_MIN")]
        [Display(Name = "Carb Min")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double CarbMin { get; set; }

        [XmlElement("CARB_MAX")]
        [Display(Name = "Carb Max")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double CarbMax { get; set; }

        [XmlElement("ABV_MIN")]
        [Display(Name = "Abv Min")]
        [Range(0, 100)]
        public double AbvMin { get; set; }

        [XmlElement("ABV_MAX")]
        [Display(Name = "Abv Max")]
        [Range(0, 100)]
        public double AbvMax { get; set; }

        [XmlElement("NOTES")]
        public string Notes { get; set; }

        [XmlElement("PROFILE")]
        public string Profile { get; set; }

        [XmlElement("INGREDIENTS")]
        public string Ingredients { get; set; }

        [XmlElement("EXAMPLES")]
        public string Examples { get; set; }

        [XmlIgnore]
        public List<Recipe> Recipes { get; set; }
    }
}
