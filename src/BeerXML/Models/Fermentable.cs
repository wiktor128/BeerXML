using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerXML.Models
{
    public class Fermentable
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FermentableId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Version { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float Amount { get; set; }

        [Required]
        [Range(0,100)]
        public float Yeld { get; set; }

        [Required]
        public float Color { get; set; }

        [Display(Name = "Add After Boil")]
        public bool AddAfterBoil { get; set; }

        public string Origin { get; set; }
        public string Supplier { get; set; }
        public string Notes { get; set; }

        [Display(Name = "Coarse Fine Diff")]
        [Range(0,100)]
        public float CoarseFineDiff { get; set; }

        [Range(0, 100)]
        public float Moisture { get; set; }

        [Display(Name = "Diastatic Power")]
        public float DiastaticPower { get; set; }

        [Range(0, 100)]
        public float Protein { get; set; }

        [Display(Name = "Max In Batch")]
        [Range(0, 100)]
        public float MaxInBatch { get; set; }

        [Display(Name = "Recommended Mash")]
        [Range(0, 100)]
        public float RecommendedMash { get; set; }

        [Display(Name = "Ibu Gal Per Lb")]
        public float IbuGalPerLb { get; set; }

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

