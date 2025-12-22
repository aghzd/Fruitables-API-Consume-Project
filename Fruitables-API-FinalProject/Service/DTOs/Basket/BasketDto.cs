namespace Service.DTOs.Basket
{
    public class BasketDto
    {
        public string CookieKey { get; set; }
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    }
}