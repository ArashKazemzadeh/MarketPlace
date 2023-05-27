
using Application.Dtos.VisitorDtos;

namespace Application.IServices.Visitors
{
    public interface IGetToDayReportService
    {
        ResultTodayReportDto Execute();
    }
}
