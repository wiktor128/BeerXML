using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerXML.Models
{
    public class Style
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StyleId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public int Version { get; set; }

        [Required]
        [Display(Name = "Category Number")]
        public string CategoryNumber { get; set; }

        [Required]
        [Display(Name = "Style Letter")]
        public string StyleLetter { get; set; }

        [Required]
        [Display(Name = "Style Guide")]
        public string StyleGuide { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [Display(Name = "OG Min")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float OgMin { get; set; }

        [Required]
        [Display(Name = "OG Max")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float OgMax { get; set; }

        [Required]
        [Display(Name = "FG Min")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float FgMin { get; set; }

        [Required]
        [Display(Name = "FG Max")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float FgMax { get; set; }

        [Required]
        [Display(Name = "IBU Min")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float IbuMin { get; set; }

        [Required]
        [Display(Name = "IBU Max")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float IbuMax { get; set; }

        [Required]
        [Display(Name = "Color Min")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float ColorMax { get; set; }

        [Required]
        [Display(Name = "Color Max")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float ColorMin { get; set; }

        [Display(Name = "Carb Min")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float CarbMin { get; set; }

        [Display(Name = "Carb Max")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float CarbMax { get; set; }

        [Display(Name = "Abv Min")]
        [Range(0, 100)]
        public float AbvMin { get; set; }

        [Display(Name = "Abv Max")]
        [Range(0, 100)]
        public float AbvMax { get; set; }

        public string Notes { get; set; }

        public string Profile { get; set; }

        public string Ingredients { get; set; }

        public string Examples { get; set; }


        public List<Recipe> Recipes { get; set; }
    }
}
