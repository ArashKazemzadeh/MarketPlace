using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.IRepositories.Dtos.Seller
{
    public class SellerRepDto
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public double CommissionPercentage { get; set; }
        public ConsoleApp1.Models.Address? Address { get; set; }
        public virtual ConsoleApp1.Models.Booth? Booth { get; set; }
    }
}
