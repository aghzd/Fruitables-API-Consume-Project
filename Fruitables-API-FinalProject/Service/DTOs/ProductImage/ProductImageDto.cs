
namespace Service.DTOs.ProductImage
{
    public class ProductImageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
    }
}