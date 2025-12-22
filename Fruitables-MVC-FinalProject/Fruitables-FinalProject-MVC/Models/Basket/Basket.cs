using System.Text.Json.Serialization;

namespace Fruitables_FinalProject_MVC.Models.Basket
{
    public class Basket
    {
        public string AppUserId { get; set; }
        [JsonPropertyName("basketItems")]
        public List<BasketItem> Items { get; set; } = new();
        public int TotalPrice => Items.Sum(i => i.TotalPrice);
    }
}