using System.ComponentModel.DataAnnotations;

namespace WebSite.EndPoint.Areas.Admin.Models
{
    public class SellerVm
    {    
        public int Id { get; set; }
        [Display(Name = "نام شرکت/دارنده غرفه")]
        public string? CompanyName { get; set; }
        [Display(Name = " فعالیت/غیرفعال")]
        public bool IsActive { get; set; }
        [Display(Name = "حذف شده/نشده")]
        public bool IsRemoved { get; set; } = false;
        [Display(Name = "درصد کمیسیون")]
        public double CommissionPercentage { get; set; }
    }
}
