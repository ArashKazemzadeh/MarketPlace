namespace Application.Dtos.VisitorDtos;

public class TodayDto
{
    public long PageViews { get; set; }
    public long Visitors { get; set; }
    public float ViewsPerVisitor { get; set; }
    public VisitCountDto VisitPerhour { get; set; }
}