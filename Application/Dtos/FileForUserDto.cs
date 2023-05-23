

namespace ConsoleApp.Models;


public class FileForUserDto
{
    public int Id { get; set; }

    public string? Url { get; set; }

    public string? Name { get; set; }

    public byte[] FileData { get; set; } = null!;

    public int? SellerId { get; set; }

}
