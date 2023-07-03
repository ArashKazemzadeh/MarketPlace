using ConsoleApp1.Models;


namespace Domin.IRepositories.Dtos.Image
{
    public class ImageForProductRepDto
    {
        public int Id { get; set; }

        public string? Url { get; set; }

        public int? ProductId { get; set; }
        public int? SellerId { get; set; }
        public virtual ConsoleApp1.Models.Product? Product { get; set; }
    }
}
