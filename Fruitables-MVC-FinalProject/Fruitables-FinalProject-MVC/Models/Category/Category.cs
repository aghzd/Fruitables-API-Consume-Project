namespace Fruitables_FinalProject_MVC.Models.Category
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Product.Product> Products { get; set; }
    }
}