using ConsoleApp1.Models;


namespace Domin.IRepositories.Dtos.Cart
{
    public class CartAddDto
    {
        public int? TotalPrices { get; set; }
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public int? SellerId { get; set; }
    }
}
