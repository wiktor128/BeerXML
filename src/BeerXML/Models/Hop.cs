using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BeerXML.Models
{
    public class Hop
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HopID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Version { get; set; }

        [Required]
        [Range(0, 100)]
        public float Alpha { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float Amount { get; set; }

        [Required]
        public string Use { get; set; }

        [Required]
        public int Time { get; set; }

        public string Notes { get; set; }

        public string Type { get; set; }

        public string Form { get; set; }

        [Range(0, 100)]
        public float Beta { get; set; }

        [Range(0, 100)]
        public float HSI { get; set; } 

        public string Origin { get; set; }

        public string Substitutes { get; set; }

        [Range(0, 100)]
        public float Humulene { get; set; }

        [Range(0, 100)]
        public float Caryophyllene { get; set; }

        [Range(0, 100)]
        public float Cohumulone { get; set; }

        [Range(0, 100)]
        public float Myrcene { get; set; }

        public List<HopRecipe> HopRecipe { get; set; }

    }

    public class HopRecipe
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int HopId { get; set; }
        public Hop Hop { get; set; }
    }
}
