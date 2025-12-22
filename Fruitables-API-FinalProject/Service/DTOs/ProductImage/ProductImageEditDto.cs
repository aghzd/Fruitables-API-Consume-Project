using Microsoft.AspNetCore.Http;

namespace Service.DTOs.ProductImage
{
    public class ProductImageEditDto
    {
        public IFormFile? Name { get; set; }
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
    }
}