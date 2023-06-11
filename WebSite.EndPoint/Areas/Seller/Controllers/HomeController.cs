using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
