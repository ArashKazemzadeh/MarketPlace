using System.ComponentModel.DataAnnotations;

namespace WebSite.EndPoint.Areas.Admin.Models
{
    public class UserVM
    {
        public int Id { get; set; }
        [Display(Name = "پست الکترونیکی")]
        public string Email { get; set; }
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }
        [Display(Name = "نقش ها")]
        public List<string> Roles { get; set; }
    }
}
