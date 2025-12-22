using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.Product
{
    public class ProductEditDto
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