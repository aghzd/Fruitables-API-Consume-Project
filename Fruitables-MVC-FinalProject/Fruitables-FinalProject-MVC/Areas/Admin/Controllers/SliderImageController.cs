using Fruitables_FinalProject_MVC.Models.SliderImage;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fruitables_FinalProject_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class SliderImageController : Controller
    {
        private readonly ISliderImageService _sliderImageService;
        public SliderImageController(ISliderImageService sliderImageService)
        {
            _sliderImageService = sliderImageService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sliderImages = await _sliderImageService.GetAllAsync();
            return View(sliderImages);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SliderImageCreate request)
        {
            if(!ModelState.IsValid) return View();

            await _sliderImageService.CreateAsync(request);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var sliderImage = await _sliderImageService.GetByIdAsync(id);
            return View(sliderImage);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sliderImageService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var sliderImage = await _sliderImageService.GetEditAsync(id);
            return View(sliderImage);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SliderImageEdit request)
        {
            if (!ModelState.IsValid) return View(request);
            await _sliderImageService.EditAsync(id, request);
            return RedirectToAction(nameof(Index));
        }
    }
}