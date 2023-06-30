using ConsoleApp1.Models;


namespace Domin.IRepositories.Dtos
{
    public class ImageForProductRepDto
    {
        public int Id { get; set; }

        public string? Url { get; set; }

        public int? ProductId { get; set; }
        public int? SellerId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
