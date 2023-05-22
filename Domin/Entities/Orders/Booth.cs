using Domin.Attributes;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;
[Auditable]

public class Booth
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? SellerId { get; set; }
    public Seller? Seller { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
