using Application.IServices.Visitors;
using Microsoft.AspNetCore.Mvc;
namespace WebSite.EndPoint.Areas.Admin.Controllers;




[Area("Admin")]
public class ForVisitorController : Controller
{
    private readonly IGetToDayReportService _getTodayReportService;
    public ForVisitorController(IGetToDayReportService getTodayReportService)
    {
        _getTodayReportService = getTodayReportService;
    }
    public IActionResult Index()
    {
        return View(_getTodayReportService.Execute());
    }
}

