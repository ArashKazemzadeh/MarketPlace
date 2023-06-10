

using ConsoleApp1.Models;

namespace Domin.IRepositories.Dtos
{
    public class CategoryRepDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
