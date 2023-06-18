using System.ComponentModel.DataAnnotations;
using ConsoleApp1.Models;

namespace WebSite.EndPoint.Areas.Admin.Models
{
    public class BoothVM
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        [Display(Name = "نام غرفه")]

        public string? Name { get; set; }
        [Display(Name = "معرفی غرفه")]

        public string? Description { get; set; }
        [Display(Name = "نام صاحب غرفه")]

        public string? Seller { get; set; }

    }
}
