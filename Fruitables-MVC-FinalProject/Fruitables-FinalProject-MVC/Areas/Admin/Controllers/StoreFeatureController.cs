using Fruitables_FinalProject_MVC.Models.StoreFeature;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fruitables_FinalProject_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class StoreFeatureController : Controller
    {
        private readonly IStoreFeatureService _service;
        public StoreFeatureController(IStoreFeatureService service)
        {
            _service = service; 
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var storeFeatures = await _service.GetAllAsync();
            return View(storeFeatures);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StoreFeatureCreate request)
        {
            if (!ModelState.IsValid) return View();
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
            var features = await _service.GetByIdAsync(id);
            return  View(features);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var feature = await _service.GetEditAsync(id);
            return View(feature);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,StoreFeatureEdit request)
        {
            if (!ModelState.IsValid) return View(request);
            await _service.EditAsync(id, request);
            return RedirectToAction(nameof(Index));
        }
    }
}