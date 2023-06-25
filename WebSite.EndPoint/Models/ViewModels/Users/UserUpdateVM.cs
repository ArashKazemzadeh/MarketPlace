using System.ComponentModel.DataAnnotations;

namespace WebSite.EndPoint.Models.ViewModels.Users;

public class UserUpdateVM
{
    [Display(Name = "پست الکترونیکی")]
    [Required (ErrorMessage = "این فیلد حتما باید پرشود")]
    public string Email { get; set; }
    [Required(ErrorMessage = "این فیلد حتما باید پرشود")]
    [Display(Name = "نام کاربری")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "این فیلد حتما باید پرشود")]
    [Display(Name = "نام")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "این فیلد حتما باید پرشود")]
    [Display(Name = "نام خانوادگی")]
    public string LastName { get; set; }
}