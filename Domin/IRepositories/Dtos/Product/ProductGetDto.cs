

namespace Domin.IRepositories.Dtos.Product
{
    public class ProductGetDto
    {
        public int Id { get; set; }
        public int BoothId { get; set; }
        public string Name { get; set; }
        public int BasePrice { get; set; }
        public string? ImageUrl { get; set; }

    }
}
