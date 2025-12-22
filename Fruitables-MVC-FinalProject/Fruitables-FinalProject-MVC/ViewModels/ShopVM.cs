using Fruitables_FinalProject_MVC.Models.Category;
using Fruitables_FinalProject_MVC.Models.Product;

namespace Fruitables_FinalProject_MVC.ViewModels
{
    public class ShopVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}