using System.ComponentModel.DataAnnotations;

namespace Fruitables_FinalProject_MVC.Models.Product
{
    public class ProductEdit
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}