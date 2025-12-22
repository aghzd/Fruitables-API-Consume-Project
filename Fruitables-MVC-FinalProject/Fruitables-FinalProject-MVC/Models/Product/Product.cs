using Fruitables_FinalProject_MVC.Models.Category;

namespace Fruitables_FinalProject_MVC.Models.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Unit { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public ICollection<ProductImage.ProductImage> ProductImages { get; set; }
    }
}