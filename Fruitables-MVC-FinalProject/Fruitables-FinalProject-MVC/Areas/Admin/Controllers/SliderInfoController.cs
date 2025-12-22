using Fruitables_FinalProject_MVC.Models.SliderInfo;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fruitables_FinalProject_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class SliderInfoController : Controller
    {
        private readonly ISliderInfoService _sliderInfoService;
        public SliderInfoController(ISliderInfoService sliderInfoService)
        {
            _sliderInfoService = sliderInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sliderInfos = await _sliderInfoService.GetAllAsync();
            return View(sliderInfos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SliderInfoCreate request)
        {
            if (!ModelState.IsValid) return View();

            await _sliderInfoService.CreateAsync(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var sliderInfo = await _sliderInfoService.GetByIdAsync(id);
            return View(sliderInfo);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sliderInfoService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _sliderInfoService.GetEditAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,SliderInfoEdit request)
        {
            if (!ModelState.IsValid) return View(request);
            await _sliderInfoService.EditAsync(id,request);
            return RedirectToAction(nameof(Index));
        }
    }
}