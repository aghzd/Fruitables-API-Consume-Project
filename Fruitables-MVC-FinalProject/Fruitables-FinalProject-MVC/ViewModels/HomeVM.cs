using Fruitables_FinalProject_MVC.Models.Category;
using Fruitables_FinalProject_MVC.Models.Product;
using Fruitables_FinalProject_MVC.Models.ProductOffer;
using Fruitables_FinalProject_MVC.Models.SliderImage;
using Fruitables_FinalProject_MVC.Models.SliderInfo;
using Fruitables_FinalProject_MVC.Models.StatsCard;
using Fruitables_FinalProject_MVC.Models.StoreFeature;

namespace Fruitables_FinalProject_MVC.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<StoreFeature> StoreFeatures { get; set; }
        public IEnumerable<SliderImage> SliderImages { get; set; }
        public IEnumerable<SliderInfo> SliderInfos { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<StatsCard> StatsCards { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductOffer> ProductOffers { get; set; }
    }
}