using Application.Dtos.VisitorDtos;
using Application.IServices.Visitors;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.Visitor
{
    public class IndexModel : PageModel
    {
        private readonly IGetToDayReportService _getTodayReportService;
        public ResultTodayReportDto ResultTodayReport;

        public IndexModel(IGetToDayReportService getTodayReportService)
        {
            _getTodayReportService = getTodayReportService;

        }
        public void OnGet()
        {
            ResultTodayReport = _getTodayReportService.Execute();
        }
    }
}
