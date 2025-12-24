using Fruitables_FinalProject_MVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fruitables_FinalProject_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ContactController : Controller
    {
        private readonly IContactAdminService _contactAdminService;
        public ContactController(IContactAdminService contactAdminService)
        {
            _contactAdminService = contactAdminService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contacts = await _contactAdminService.GetAllAsync();
          
            return View(contacts);
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var contact = await _contactAdminService.GetByIdAsync(id);
            return View(contact);
        }


        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactAdminService.DeleteAsync(id);
           
            return Ok();
        }

    }
}