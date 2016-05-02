using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Mvc;

namespace BeerXML.Models
{
    public class Recipe // to do conditional
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Version { get; set; }

        [Required]
        public string Type { get; set; } // todo validation by list

        //public Style Style { get; set; }

        //public Equipment Equipment{ get; set; }

        [Required]
        public string Brewer { get; set; }

        public string AsstBrewer { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float BatchSize { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float BoilSize { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int BoilTime { get; set; }

        [Range(0, 100)]
        public float Efficiency { get; set; } // Conditional, depend on  Type

        [Required]
        public virtual List<HopRecipe> HopRecipe { get; set; }
        
        [Required]
        public virtual List<FermentableRecipe> FermentableRecipe { get; set; }
        //public Miscs Misc { get; set; }
        
        [Required]
        public virtual List<YeastRecipe> YeastRecipe { get; set; }

        [Required]
        public virtual List<WaterRecipe> WaterRecipe { get; set; }

        //public int Mash Mash { get; set; }

        public string Notes { get; set; }

        public string TasteNotes{ get; set; }

        public float TasteRating { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double OG { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public double FG { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int FermentationStages { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int PrimaryAges { get; set; }

        public float PrimaryTemp { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int SecondaryAge { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float SecondaryTemp { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int TertiaryAge { get; set; }

        public float TertiaryTemp { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int Age { get; set; }

        public float AgeTemp { get; set; }

        public string Date { get; set; } // to do DATETIME

        [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float Carbonation { get; set; }


        public bool ForcedCarbonation { get; set; }

        public string PrimingSugarName { get; set; }

        public float CarbonationTemp { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float PrimingSugarEquiv { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float KegPrimingFactor{ get; set; }
    }
}
