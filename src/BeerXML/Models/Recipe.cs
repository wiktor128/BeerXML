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
    public class Recipe // todo conditional property
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

        #region XML De/Serialization
        [XmlArray("EQUIPMENTS")]
        [XmlArrayItem("EQUIPMENT")]
        [NotMapped]
        [ScaffoldColumn(false)]
        public List<Equipment> Equipments = new List<Equipment>();

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
        public List<Hop> Hops = new List<Hop>();

        [XmlArray("FERMENTABLES")]
        [XmlArrayItem("FERMENTABLE")]
        [NotMapped]
        [ScaffoldColumn(false)]
        public List<Fermentable> Fermentables = new List<Fermentable>();

        [XmlArray("MISCS")]
        [XmlArrayItem("MISC")]
        [ScaffoldColumn(false)]
        public List<Misc> Miscs = new List<Misc>();

        [XmlArray("YEASTS")]
        [XmlArrayItem("YEAST")]
        [NotMapped]
        [ScaffoldColumn(false)]
        public List<Yeast> Yeasts = new List<Yeast>();

        [XmlArray("WATERS")]
        [XmlArrayItem("WATER")]
        [NotMapped]
        [ScaffoldColumn(false)]
        public List<Water> Waters = new List<Water>();

        [XmlArray("MASHS")]
        [XmlArrayItem("MASH")]
        [NotMapped]
        [ScaffoldColumn(false)]
        public List<Mash> Mashs = new List<Mash>();

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

        public bool SaveAfterSerialization()
        {
            BeerXmlContext db = new BeerXmlContext();

            //save Style
            var styleEnt = db.Style.Add(this.Style).Entity;

            //save Recipe
            this.StyleId = styleEnt.StyleId;
            var recipeEnt = db.Recipes.Add(this).Entity;

            //save Waters
            if (Waters != null)
            {
                foreach (var item in Waters)
                {
                    var waterEnt = db.Waters.Add(item).Entity;
                    db.WatersRecipes.Add(new WaterRecipe()
                    {
                        Recipe = recipeEnt,
                        RecipeId = recipeEnt.RecipeId,
                        Water = waterEnt,
                        WaterId = waterEnt.WaterId
                    });
                }
            }

            //save Hops
            if (Hops != null)
            {
                foreach (var item in Hops)
                {
                    var hopEnt = db.Hops.Add(item).Entity;
                    db.HopRecipes.Add(new HopRecipe()
                    {
                        Recipe = recipeEnt,
                        RecipeId = recipeEnt.RecipeId,
                        Hop = hopEnt,
                        HopId = hopEnt.HopId
                    });
                }
            }

            //save Fermentables
            if (Fermentables != null)
            {
                foreach (var item in Fermentables)
                {
                    var fermentableEnt = db.Fermentable.Add(item).Entity;
                    db.FermentableRecipes.Add(new FermentableRecipe()
                    {
                        Recipe = recipeEnt,
                        RecipeId = recipeEnt.RecipeId,
                        Fermentable = fermentableEnt,
                        FermentableId = fermentableEnt.FermentableId
                    });
                }
            }

            //save Yeasts
            if (Yeasts != null)
            {
                foreach (var item in Yeasts)
                {
                    var yeastEnt = db.Yeast.Add(item).Entity;
                    db.YeastRecipe.Add(new YeastRecipe()
                    {
                        Recipe = recipeEnt,
                        RecipeId = recipeEnt.RecipeId,
                        Yeast = yeastEnt,
                        YeastId = yeastEnt.YeastId
                    });
                }
            }

            //save Miscs
            if (Miscs != null)
            {
                foreach (var item in Miscs)
                {
                    var miscEnt = db.Misc.Add(item).Entity;
                    db.MiscRecipe.Add(new MiscRecipe()
                    {
                        Recipe = recipeEnt,
                        RecipeId = recipeEnt.RecipeId,
                        Misc = miscEnt,
                        MiscId = miscEnt.MiscId
                    });
                }
            }

            //save Equipments
            if (Equipments != null)
            {
                foreach (var item in Equipments)
                {
                    var equipmentEnt = db.Equipment.Add(item).Entity;
                    db.EquipmentRecipe.Add(new EquipmentRecipe()
                    {
                        Recipe = recipeEnt,
                        RecipeId = recipeEnt.RecipeId,
                        Equipment = equipmentEnt,
                        EquipmentId = equipmentEnt.EquipmentId
                    });
                }
            }

            // save Mashs and MashSteps
            if (Mashs != null)
            {
                foreach (var itemMash in Mashs)
                {
                    var mashEnt = db.Mash.Add(itemMash).Entity;
                    db.MashRecipe.Add(new MashRecipe()
                    {
                        Recipe = recipeEnt,
                        RecipeId = recipeEnt.RecipeId,
                        Mash = mashEnt,
                        MashId = mashEnt.MashId
                    });
                    if (itemMash.MashSteps != null)
                    {
                        foreach (var itemStep in itemMash.MashSteps)
                        {
                            if (itemStep.Name != null) //  zabezpieczenie z powodu luki w oknie modal js
                            {
                                var mashStepEnt = db.MashStep.Add(itemStep).Entity;

                                var mashStepMash = db.MashStepMash.Add(new MashStepMash()
                                {
                                    Mash = mashEnt,
                                    MashId = mashEnt.MashId,
                                    MashStep = mashStepEnt,
                                    MashStepId = mashStepEnt.MashStepId
                                }).Entity;
                            }
                        }
                    }
                }
            }
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion
    }
}
