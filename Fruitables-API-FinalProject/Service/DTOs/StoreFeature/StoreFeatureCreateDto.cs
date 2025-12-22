using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.StoreFeature
{
    public class StoreFeatureCreateDto
    {
        [Required]
        public string IconName { get; set; }
        [Required]
        public string Feature { get; set; }
        [Required]
        public string Description { get; set; }
    }
}