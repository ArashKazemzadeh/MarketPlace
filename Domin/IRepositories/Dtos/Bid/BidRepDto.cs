using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.IRepositories.Dtos.Bid
{
    public class BidRepDto
    {
        public int Id { get; set; }

        public int? Price { get; set; }
        public DateTime? RegisterDate { get; set; } = DateTime.Now;

        public bool? IsAccepted { get; set; }

        public int? AuctionId { get; set; }

        public virtual ConsoleApp1.Models.Auction? Auction { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
