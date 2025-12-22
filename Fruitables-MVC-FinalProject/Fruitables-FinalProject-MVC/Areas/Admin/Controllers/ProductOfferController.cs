using Fruitables_FinalProject_MVC.Models.ProductOffer;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fruitables_FinalProject_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ProductOfferController : Controller
    {
        private readonly IProductOfferService _service;
        public ProductOfferController(IProductOfferService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productOffers = await _service.GetAllAsync();
            return View(productOffers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductOfferCreate request)
        {
            await _service.CreateAsync(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var productOffer = await _service.GetByIdAsync(id);
            return View(productOffer);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var productOffer = await _service.GetEditAsync(id);
            return View(productOffer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,ProductOfferEdit request)
        {
            if (!ModelState.IsValid) return View(request);
            await _service.EditAsync(id,request);
            return RedirectToAction(nameof(Index));
        }
    }
}