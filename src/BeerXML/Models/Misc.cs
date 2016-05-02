using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerXML.Models
{
    public class Misc
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MiscId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Version { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Use { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int Time { get; set; }


        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float Amount { get; set; }

        [Display(Name = "Amount Is Weight")]
        public bool AmountIsWeight { get; set; }

        [Display(Name = "Use For")]
        public string UseFor { get; set; }

        public string Notes { get; set; }

        public List<MiscRecipe> MiscRecipe { get; set; }
    }

    public class MiscRecipe
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int MiscId { get; set; }
        public Misc Misc { get; set; }
    }
}
