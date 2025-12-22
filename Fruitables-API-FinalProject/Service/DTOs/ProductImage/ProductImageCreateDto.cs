using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.ProductImage
{
    public class ProductImageCreateDto
    {
        [Required]
        public IFormFile Name { get; set; }
        [Required]
        public bool IsMain { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}