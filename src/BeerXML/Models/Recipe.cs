using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Mvc;
using System.Xml.Serialization;

namespace BeerXML.Models
{
    [XmlRoot("RECIPE")]
    public class Recipe // to do conditional
    {
        [XmlIgnore]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeId { get; set; }

        [XmlElement("NAME")]
        [Required]
        public string Name { get; set; }

        [XmlElement("VERSION")]
        [Required]
        public double Version { get; set; }

        [XmlElement("TYPE")]
        [Required]
        public string Type { get; set; } // todo validation by list

        [ForeignKey("Style")]
        public int StyleId { get; set; }

        [XmlElement("STYLE")]
        [Required]
        //[NotMapped]
        public Style Style { get; set; }

        [XmlIgnore]
        [Required]
        public virtual List<EquipmentRecipe> EquipmentRecipe { get; set; }

        [XmlElement("BREWER")]
        [Required]
        public string Brewer { get; set; }

        [XmlElement("ASST_BREWER")]
        public string AsstBrewer { get; set; }

        [XmlElement("BATCH_SIZE")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double BatchSize { get; set; }

        [XmlElement("BOIL_SIZE")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double BoilSize { get; set; }

        [XmlElement("BOIL_TIME")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double BoilTime { get; set; }

        [XmlElement("EFFICIENCY")]
        [Range(0, 100)]
        public double Efficiency { get; set; } // Conditional, depend on  Type

        [XmlIgnore]
        [Required]
        public virtual List<HopRecipe> HopRecipe { get; set; }

        [XmlIgnore]
        [Required]
        public virtual List<FermentableRecipe> FermentableRecipe { get; set; }

        [XmlIgnore]
        [Required]
        public virtual List<MiscRecipe> MiscRecipe { get; set; }
        
        [XmlIgnore]
        [Required]
        public virtual List<YeastRecipe> YeastRecipe { get; set; }
        
        [XmlIgnore]
        [Required]
        public virtual List<WaterRecipe> WaterRecipe { get; set; }
        
        [XmlIgnore]
        [Required]
        public virtual List<MashRecipe> MashRecipe { get; set; }
        
        [XmlElement("NOTES")]
        public string Notes { get; set; }

        [XmlElement("TEST_NOTES")]
        public string TasteNotes{ get; set; }

        [XmlElement("TASTE_RATING")]
        public double TasteRating { get; set; }

        [XmlElement("OG")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double OG { get; set; }

        [XmlElement("FG")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double FG { get; set; }

        [XmlElement("FERMENTATION_STAGES")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double FermentationStages { get; set; }

        [XmlElement("PRIMARY_AGES")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double PrimaryAges { get; set; }

        [XmlElement("PRIMARY_TEMP")]
        public double PrimaryTemp { get; set; }

        [XmlElement("SECONDARY_AGE")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double SecondaryAge { get; set; }

        [XmlElement("SECONDARY_TEMP")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double SecondaryTemp { get; set; }

        [XmlElement("TERTIARY_AGE")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double TertiaryAge { get; set; }

        [XmlElement("TERTIARY_TEMP")]
        public double TertiaryTemp { get; set; }

        [XmlElement("AGE")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double Age { get; set; }

        [XmlElement("AGE_TEMP")]
        public double AgeTemp { get; set; }

        [XmlElement("DATE")]
        public string Date { get; set; } // to do DATETIME

        [XmlElement("CARBONATION")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double Carbonation { get; set; }

        [XmlElement("FORCED_CARBONATION")]
        public bool ForcedCarbonation { get; set; }

        [XmlElement("PRIMING_SUGAR_NAME")]
        public string PrimingSugarName { get; set; }

        [XmlElement("CARBONATION_TEMP")]
        public double CarbonationTemp { get; set; }

        [XmlElement("PRIMING_SUGAR_EQUIV")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double PrimingSugarEquiv { get; set; }

        [XmlElement("KEG_PRIMING_FACTOR")]
        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double KegPrimingFactor{ get; set; }

        #region XML Only Fields
        [XmlArray("EQUIPMENTS")]
        [XmlArrayItem("EQUIPMENT")]
        [NotMapped]
        [ScaffoldColumn(false)]
        public List<Equipment> Equipments;

        [XmlElement("EQUIPMENT")]
        [NotMapped]
        [ScaffoldColumn(false)]
        public Equipment Equipment
        {
            get
            {
                if (Equipments != null)
                {
                    return Equipments.FirstOrDefault();
                }
                return null;
            }

            set
            {
                Equipments.Add(value);
            }
        }

        [XmlArray("HOPS")]
        [XmlArrayItem("HOP")]
        [NotMapped]
        [ScaffoldColumn(false)]
        public List<Hop> Hops;

        [XmlArray("FERMENTABLES")]
        [XmlArrayItem("FERMENTABLE")]
        [NotMapped]
        [ScaffoldColumn(false)]
        public List<Fermentable> Fermentables;

        [XmlArray("MISCS")]
        [XmlArrayItem("MISC")]
        [ScaffoldColumn(false)]
        public List<Misc> Miscs;

        [XmlArray("YEASTS")]
        [XmlArrayItem("YEAST")]
        [NotMapped]
        [ScaffoldColumn(false)]
        public List<Yeast> Yeasts;

        [XmlArray("WATERS")]
        [XmlArrayItem("WATER")]
        [NotMapped]
        [ScaffoldColumn(false)]
        public List<Water> Waters;

        [XmlArray("MASHS")]
        [XmlArrayItem("MASH")]
        [NotMapped]
        [ScaffoldColumn(false)]
        public List<Mash> Mashs;

        [XmlElement("MASH")]
        [NotMapped]
        [ScaffoldColumn(false)]
        public Mash Mash
        {
            get
            {
                if (Mashs != null)
                {
                    return Mashs.FirstOrDefault();
                }
                return null;
            }

            set
            {
                Mashs.Add(value);
            }
        }
        #endregion
    }
}
