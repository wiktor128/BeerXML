using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerXML.Models
{
    public class Yeast
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YeastId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Version { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Form { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float Amount { get; set; }

        [Display(Name = "Amount Is Weight")]
        public bool AmountIsWeight { get; set; }

        public string Laboratory { get; set; }

        [Display(Name = "Product ID")]
        public string ProductID { get; set; }

        [Display(Name = "Min Temperature")]
        public float MinTemperature { get; set; }

        [Display(Name = "Max Temperature")]
        public float MaxTemperature { get; set; }

        public string Flocculation { get; set; }

        [Range(0,100)]
        public float Attenuation { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Best For")]
        public string BestFor { get; set; }

        [Display(Name = "Times Cultured")]
        [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int TimesCultured { get; set; }

        [Display(Name = "Max Reuse")]
        [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int MaxReuse { get; set; }

        [Display(Name = "Add To Secondary")]
        public bool AddToSecondary { get; set; }

        public List<YeastRecipe> YeastRecipe { get; set; }
    }

    public class YeastRecipe
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int YeastId { get; set; }
        public Yeast Yeast { get; set; }
    }
}
