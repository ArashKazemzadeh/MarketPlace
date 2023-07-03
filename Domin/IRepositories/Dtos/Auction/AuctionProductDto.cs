using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.IRepositories.Dtos.Auction
{
    public class AuctionProductDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? BasePrice { get; set; }
        public int AuctionId { get; set; }
        public bool IsActive { get; set; }
        public int? Availability { get; set; }
        public DateTime? StartDeadTime { get; set; }
        public DateTime? EndDeadTime { get; set; }
        public int HighestPrice { get; set; }
        public List<string> ImagesUrls { get; set; }
    }
}
