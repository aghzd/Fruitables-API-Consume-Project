using System.ComponentModel.DataAnnotations;

namespace Fruitables_FinalProject_MVC.Models.ProductOffer
{
    public class ProductOfferEdit
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public string BackgroundColor { get; set; }
        [Required]
        public string NameColor { get; set; }
        [Required]
        public string TextColor { get; set; }
    }
}