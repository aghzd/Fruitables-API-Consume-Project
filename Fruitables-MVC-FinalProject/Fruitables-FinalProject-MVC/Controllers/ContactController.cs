using Fruitables_FinalProject_MVC.Models.Contact;
using Fruitables_FinalProject_MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fruitables_FinalProject_MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;
        public ContactController(IContactService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactCreate request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            await _service.CreateAsync(request);
            return View(request);
        }

    }
}