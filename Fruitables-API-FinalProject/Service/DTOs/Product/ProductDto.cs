using Service.DTOs.ProductImage;

namespace Service.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Unit { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public ICollection<ProductImageDto> ProductImages { get; set; }
    }
}