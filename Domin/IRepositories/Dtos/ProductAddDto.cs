using ConsoleApp1.Models;

namespace Domin.IRepositories.Dtos
{
    public class ProductAddDto
    {
        public string? Name { get; set; }
        public int? BasePrice { get; set; }
        public int? Availability { get; set; }
        public string? Description { get; set; }
        public int? BoothId { get; set; }
        public virtual Booth? Booth { get; set; }
        //public virtual ICollection<ImageForProduct> Images { get; set; } = new List<ImageForProduct>();
        //public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
