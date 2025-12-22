using Fruitables_FinalProject_MVC.Models.StatsCard;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fruitables_FinalProject_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class StatsCardController : Controller
    {
        private readonly IStatsCardService _service;
        public StatsCardController(IStatsCardService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var statsCard = await _service.GetAllAsync();
            return View(statsCard);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StatsCardCreate request)
        {
            if (!ModelState.IsValid)
                return View(request);

            await _service.CreateAsync(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var statsCard = await _service.GetByIdAsync(id);
            return View(statsCard);
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
            var statsCard = await _service.GetEditAsync(id);
            return View(statsCard);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,StatsCardEdit request)
        {
            if (!ModelState.IsValid) return View(request);
            await _service.EditAsync(id, request);
            return RedirectToAction(nameof(Index));
        }
    }
}