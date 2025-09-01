using Microsoft.AspNetCore.Mvc;

namespace DemoShopApplication.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
