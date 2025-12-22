using Fruitables_FinalProject_MVC.Services.Interfaces;
using Fruitables_FinalProject_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fruitables_FinalProject_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderImageService _sliderImageService;
        private readonly ISliderInfoService _sliderInfoService;
        private readonly IStoreFeatureService _storeFeatureService;
        private readonly ICategoryService _categoryService;
        private readonly IStatsCardService _statsCardService;
        private readonly IProductService _productService;
        private readonly IProductOfferService _productOfferService;

        public HomeController(ISliderImageService sliderImageService,
                              ISliderInfoService sliderInfoService,
                              IStoreFeatureService storeFeatureService,
                              ICategoryService categoryService,
                              IStatsCardService statsCardService,
                              IProductService productService,
                              IProductOfferService productOfferService)
        {
            _sliderImageService = sliderImageService;
            _sliderInfoService = sliderInfoService;
            _storeFeatureService = storeFeatureService;
            _categoryService = categoryService;
            _statsCardService = statsCardService;
            _productService = productService;
            _productOfferService = productOfferService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            var sliderImages = await _sliderImageService.GetAllAsync();
            var sliderInfos = await  _sliderInfoService.GetAllAsync();
            var storeFeatures = await _storeFeatureService.GetAllAsync();
            var statsCards = await _statsCardService.GetAllAsync();
            var products = await _productService.GetAllAsync();
            var productOffers = await _productOfferService.GetAllAsync();


            var model = new HomeVM
            {
                Categories = categories,
                SliderImages = sliderImages,
                SliderInfos = sliderInfos,
                StoreFeatures = storeFeatures,
                StatsCards = statsCards,
                Products = products,
                ProductOffers = productOffers
            };

            return View(model);
        }
    }
}   