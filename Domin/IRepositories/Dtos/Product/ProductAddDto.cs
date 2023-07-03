using ConsoleApp1.Models;

namespace Domin.IRepositories.Dtos.Product
{
    public class ProductAddDto
    {
        public string? Name { get; set; }
        public int? BasePrice { get; set; }
        public int? Availability { get; set; }
        public string? Description { get; set; }
        public int? BoothId { get; set; }
        public virtual ConsoleApp1.Models.Booth? Booth { get; set; }
      
    }
}
