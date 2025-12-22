using Fruitables_FinalProject_MVC.Models.ProductImage;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fruitables_FinalProject_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _service;
        public ProductImageController(IProductImageService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productImages = await _service.GetAllAsync();
            return View(productImages);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductImageCreate request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            await _service.CreateAsync(request);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var productImage = await _service.GetByIdAsync(id);
            return View(productImage);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var productImage = await _service.GetEditAsync(id);
            return View(productImage);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,ProductImageEdit request)
        {
            if (!ModelState.IsValid) return View(request);
            await _service.EditAsync(id, request);
            return RedirectToAction(nameof(Index));
        }
    }
}