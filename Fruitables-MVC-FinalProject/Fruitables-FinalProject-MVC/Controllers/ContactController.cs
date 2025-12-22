using Microsoft.AspNetCore.Mvc;

namespace Fruitables_FinalProject_MVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
