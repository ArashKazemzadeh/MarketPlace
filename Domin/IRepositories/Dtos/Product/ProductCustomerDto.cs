﻿using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.IRepositories.Dtos.Product
{
    public class ProductCustomerDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? BasePrice { get; set; }
        public int? Availability { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }

        public int? BoothId { get; set; }
        public string BoothName { get; set; }
        public List<string> ImagesUrls { get; set; }
        public List<string> Categories { get; set; }
    }
}
