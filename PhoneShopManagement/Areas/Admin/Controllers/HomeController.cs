using Microsoft.AspNetCore.Mvc;

namespace PhoneShopManagement.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
