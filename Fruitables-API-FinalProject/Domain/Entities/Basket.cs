namespace Domain.Entities
{
    public class Basket:BaseEntity
    {
        public string CookieKey { get; set; }   
        public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}