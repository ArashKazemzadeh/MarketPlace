

namespace Domin.IRepositories.Dtos
{
    public class AddressRepDto
    {
        public string? City { get; set; }

        public string? Street { get; set; }

        public string? Description { get; set; }

        public int? CustomerId { get; set; }
        public int? AddressId { get; set; }
        public int? SellerId { get; set; }

    }
}
