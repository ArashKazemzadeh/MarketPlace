namespace Application.Dtos.VisitorDtos;

    public class ResultTodayReportDto
    {
        public GeneralStateDto GeneralState { get; set; }
        public TodayDto Today { get; set; }
        public List<VisitorsDto> Visitors { get; set; }
    }

