

using ConsoleApp1.Models;

namespace Domin.IRepositories.Dtos.Category
{
    public class CategoryRepDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
        public ICollection<ConsoleApp1.Models.Product> Products { get; set; }
    }
}
