using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerXML.Models
{
    public class Mash
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MashId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Version { get; set; }

        [Required]
        [Display(Name = "Grain Temp")]
        public float GrainTemp { get; set; }

        [Required]
        public virtual List<MashStepMash> MashStepMash { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Tun Temp")]
        public float TunTemp { get; set; }

        [Display(Name = "Sparge Temp")]
        public float SpargeTemp { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float Ph { get; set; }

        [Display(Name = "Tun Weight")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float TunWeight { get; set; }

        [Display(Name = "Tun Specific Heat")]
        public float TunspecificHeat { get; set; }

        [Display(Name = "Equip Adjust")]
        public bool EquipAdjust { get; set; }

        public List<MashRecipe> MashRecipe { get; set; }
    }

    public class MashRecipe
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int MashId { get; set; }
        public Mash Mash { get; set; }
    }
}
