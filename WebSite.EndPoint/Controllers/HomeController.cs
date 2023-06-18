using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Utilities.Filters;


namespace WebSite.EndPoint.Controllers
{
    [ServiceFilter(typeof(SaveVisitorFilter))]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

    }
}