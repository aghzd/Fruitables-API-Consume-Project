using System.ComponentModel.DataAnnotations;

namespace Fruitables_FinalProject_MVC.Models.StoreFeature
{
    public class StoreFeatureCreate
    {
        [Required]
        public string IconName { get; set; }
        [Required]
        public string Feature { get; set; }
        [Required]
        public string Description { get; set; }
    }
}