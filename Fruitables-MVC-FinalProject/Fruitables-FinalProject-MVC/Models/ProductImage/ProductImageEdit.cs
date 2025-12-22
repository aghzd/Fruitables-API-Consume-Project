using System.ComponentModel.DataAnnotations;

namespace Fruitables_FinalProject_MVC.Models.ProductImage
{
    public class ProductImageEdit
    {
        [Required]
        public IFormFile? Name { get; set; }
        [Required]
        public bool IsMain { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}