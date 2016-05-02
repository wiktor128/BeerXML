using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerXML.Models
{
    public class Equipment
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipmentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Version { get; set; }

        [Display(Name = "Boil Size")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        [Required]
        public float BoilSize { get; set; }

        [Display(Name = "Batch Size")]
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float BatchSize { get; set; }

        [Display(Name = "Tun Volume")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float TunVolume { get; set; }

        [Display(Name = "Tun Weight")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float TunWeight { get; set; }

        [Display(Name = "Tun Specific Heat")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float TunSpecificHeat { get; set; }

        [Display(Name = "Top Up Water")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float TopUpWater { get; set; }

        [Display(Name = "Trub Chiller Loss")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float TrubChillerLoss { get; set; }

        [Display(Name = "Evap Rate")]
        [Range(0, 100)]
        public float EvapRate { get; set; }

        [Display(Name = "Boil Time")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float BoilTime { get; set; }

        [Display(Name = "Calc Boil Volume")]
        public bool CalcBoilVolume { get; set; }

        [Display(Name = "Lauter Deadspace")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float LauterDeadspace { get; set; }

        [Display(Name = "Top Up Kettle")]
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float TopUpKettle { get; set; }

        [Display(Name = "Hop Utilization")]
        [Range(0, 100)]
        public float HopUtilization { get; set; }

        public string Notes { get; set; }

        public List<EquipmentRecipe> EquipmentRecipe { get; set; }
    }

    public class EquipmentRecipe
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment{ get; set; }
    }
}
