namespace Fruitables_FinalProject_MVC.Models.Basket
{
    public class Basket
    {
        public string CookieKey { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();

        public decimal TotalPrice
            => BasketItems?.Sum(x => x.Price * x.Quantity) ?? 0;
    }
}