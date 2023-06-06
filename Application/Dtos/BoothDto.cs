using System.ComponentModel.DataAnnotations;
namespace ConsoleApp.Models;


public class BoothDto
{
    public int Id { get; set; }
    [Display(Name = "نام غرفه")]
    public string? Name { get; set; }
    [Display(Name = "توضیحات")]

    public string? Description { get; set; }
    public int? SellerId { get; set; }
    public string? Seller { get; set; }

}
