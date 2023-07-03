using System.ComponentModel.DataAnnotations;

namespace WebSite.EndPoint.Areas.Seller.Models
{
    public class AuctionAddVm
    {
       
        public int ProductId { get; set; }

        [Display(Name = "سال آغاز مزایده")]
        [Required(ErrorMessage = "فیلد سال آغاز مزایده اجباری است.")]
        public int YearStartSelected { get; set; }

        [Display(Name = "ماه آغاز مزایده")]
        [Required(ErrorMessage = "فیلد ماه آغاز مزایده اجباری است.")]
        public string MonthStartSelected { get; set; }

        [Display(Name = "روز آغاز مزایده")]
        [Required(ErrorMessage = "فیلد روز آغاز مزایده اجباری است.")]
        public int DayStartSelected { get; set; }

        [Display(Name = "ساعت آغاز مزایده")]
        [Required(ErrorMessage = "فیلد ساعت آغاز مزایده اجباری است.")]
        public int HourStartSelected { get; set; }

        [Display(Name = "دقیقه آغاز مزایده")]
        [Required(ErrorMessage = "فیلد دقیقه آغاز مزایده اجباری است.")]
        public int MinuteStartSelected { get; set; }

        [Display(Name = "سال پایان مزایده")]
        [Required(ErrorMessage = "فیلد سال پایان مزایده اجباری است.")]
        public int YearEndSelected { get; set; }

        [Display(Name = "ماه پایان مزایده")]
        [Required(ErrorMessage = "فیلد ماه پایان مزایده اجباری است.")]
        public string MonthEndSelected { get; set; }

        [Display(Name = "روز پایان مزایده")]
        [Required(ErrorMessage = "فیلد روز پایان مزایده اجباری است.")]
        public int DayEndSelected { get; set; }

        [Display(Name = "ساعت پایان مزایده")]
        [Required(ErrorMessage = "فیلد ساعت پایان مزایده اجباری است.")]
        public int HourEndSelected { get; set; }

        [Display(Name = "دقیقه پایان مزایده")]
        [Required(ErrorMessage = "فیلد دقیقه پایان مزایده اجباری است.")]
        public int MinuteEndSelected { get; set; }
    }

}
