using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.VisitorDtos
{
    /// <summary>
    /// تعداد کل بازدید های یک شخص از سایت
    /// </summary>
    public class GeneralStateDto
    {
        public long TotalPageViews { get; set; }
        public long TotalVisitors { get; set; }
        public float PageViewsPerVisit { get; set; }
        public VisitCountDto VisitPerDay { get; set; }
    }
}
