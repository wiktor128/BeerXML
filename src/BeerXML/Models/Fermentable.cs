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
    public class Fermentable
    {
        [XmlIgnore]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FermentableId { get; set; }

        [XmlElement("NAME")]
        [Required]
        public string Name { get; set; }

        [XmlElement("VERSION")]
        [Required]
        public double Version { get; set; }

        [XmlElement("TYPE")]
        [Required]
        public string Type { get; set; }

        [XmlElement("AMOUNT")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double Amount { get; set; }

        [XmlElement("YELD")]
        [Required]
        [Range(0,100)]
        public double Yeld { get; set; }

        [XmlElement("COLOR")]
        [Required]
        public double Color { get; set; }

        [XmlIgnore]
        [Display(Name = "Add After Boil")]
        public bool AddAfterBoil { get; set; }

        [XmlElement("ADD_AFTER_BOIL")]
        [ScaffoldColumn(false)]
        [NotMapped]
        public string AddAfterBoilAsString
        {
            get
            {
                return XmlConvert.ToString(AddAfterBoil);
            }

            set
            {
                bool ParsedValue;

                if (!Boolean.TryParse(value, out ParsedValue))
                    ParsedValue = XmlConvert.ToBoolean(value);

                AddAfterBoil = ParsedValue;
            }
        }

        [XmlElement("ORIGIN")]
        public string Origin { get; set; }

        [XmlElement("SUPPLIER")]
        public string Supplier { get; set; }

        [XmlElement("NOTES")]
        public string Notes { get; set; }

        [XmlElement("COARSE_FINE_DIFF")]
        [Display(Name = "Coarse Fine Diff")]
        [Range(0,100)]
        public double CoarseFineDiff { get; set; }

        [XmlElement("MOISTURE")]
        [Range(0, 100)]
        public double Moisture { get; set; }

        [XmlElement("DIASTATIC_POWER")]
        [Display(Name = "Diastatic Power")]
        public double DiastaticPower { get; set; }

        [XmlElement("PROTEIN")]
        [Range(0, 100)]
        public double Protein { get; set; }

        [XmlElement("MAX_IN_BATCH")]
        [Display(Name = "Max In Batch")]
        [Range(0, 100)]
        public double MaxInBatch { get; set; }

        [XmlElement("RECOMMENDED_MASH")]
        [Display(Name = "Recommended Mash")]
        [Range(0, 100)]
        public double RecommendedMash { get; set; }

        [XmlElement("IBU_GAL_PER_LB")]
        [Display(Name = "Ibu Gal Per Lb")]
        public double IbuGalPerLb { get; set; }

        [XmlIgnore]
        public List<FermentableRecipe> FermentableRecipe { get; set; }
    }

    public class FermentableRecipe
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int FermentableId { get; set; }
        public Fermentable Fermentable { get; set; }
    }
}

