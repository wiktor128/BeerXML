using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BeerXML.Models
{
    public class Water
    {
        public int WaterId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Version { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float Amount { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float Calcium { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float Bicarbonate { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float Sulfate { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float Chloride { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float Sodium { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float Magnesium { get; set; }

        [Range(0, 14, ErrorMessage = "The value must be in range [0,14]")]
        public float Ph { get; set; }

        public String Notes { get; set; }

        public List<WaterRecipe> WaterRecipes { get; set; }
    }
    
    public class WaterRecipe
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int WaterId { get; set; }
        public Water Water { get; set; }
    }
}
