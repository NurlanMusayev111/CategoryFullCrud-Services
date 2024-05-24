using Microsoft.AspNetCore.Mvc;

namespace FiorelloSlider_OnetoMany.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
