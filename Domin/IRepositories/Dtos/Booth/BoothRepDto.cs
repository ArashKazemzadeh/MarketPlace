using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domin.IRepositories.Dtos.Booth
{
    public class BoothRepDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? SellerId { get; set; }
        public int? BoothId { get; set; }
        public string? Seller { get; set; }
    }
}
