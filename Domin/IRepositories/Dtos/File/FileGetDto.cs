using ConsoleApp1.Models;

namespace Domin.IRepositories.Dtos.File;

public class FileGetDto
{

    public int Id { get; set; }

    public string? Url { get; set; }

    public string? Name { get; set; }

    public int? SellerId { get; set; }

    public virtual ConsoleApp1.Models.Seller? Seller { get; set; }
}