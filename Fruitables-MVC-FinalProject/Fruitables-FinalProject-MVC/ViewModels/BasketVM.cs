using Fruitables_FinalProject_MVC.Models.Basket;

namespace Fruitables_FinalProject_MVC.ViewModels
{
    public class BasketVM
    {
        public string UserId { get; set; }
        public List<BasketItem> Items { get; set; }
        public int TotalPrice => Items.Sum(i => i.TotalPrice);
    }
}