using ConsoleApp1.Models;

namespace WebSite.EndPoint.Areas.Admin.Models
{
    public class BoothVM
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Seller { get; set; }

    }
}
