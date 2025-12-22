namespace Fruitables_FinalProject_MVC.Models.Basket
{
    public class BasketItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public string ImageUrl { get; set; }

        public int TotalPrice => Price * Quantity;
    }
}