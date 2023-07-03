using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.IRepositories.Dtos.Cart
{
    public class ProductInCartRepDto
    {
        public int ProductId { get; set; }
        public int TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int BasePrice { get; set; }
        public string Name { get; set; }
    }
}
