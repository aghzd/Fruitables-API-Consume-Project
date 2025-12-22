using Fruitables_FinalProject_MVC.Services.Interfaces;
using Fruitables_FinalProject_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fruitables_FinalProject_MVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ShopController(IProductService productService,
                              ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            var categories = await _categoryService.GetAllAsync();
            var model = new ShopVM
            {
                Products = products,
                Categories = categories
            };
            return View(model);
        }
    }
}