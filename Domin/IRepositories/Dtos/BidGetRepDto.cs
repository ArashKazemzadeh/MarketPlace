using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.IRepositories.Dtos
{
    public class BidGetRepDto
    {
        public int Id { get; set; }
        public int? Price { get; set; }
        public string ProductName { get; set; }//
        public DateTime? RegisterDate { get; set; }
        public bool? IsAccepted { get; set; }
        public int? AuctionId { get; set; }
        public DateTime? EndDateAuction { get; set; }
        public DateTime? StartDateAuction { get; set; }
        public virtual int? CustomerId { get; set; }
    }
}
