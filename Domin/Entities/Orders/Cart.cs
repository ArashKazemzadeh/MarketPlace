﻿using Domin.Attributes;

namespace ConsoleApp1.Models;
[Auditable]

public class Cart
{
    public int Id { get; set; }

    public int? TotalPrices { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }
    public int? SellerId { get; set; }

    public virtual Seller? Seller { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<ProductsCart> ProductsCarts { get; set; } = new List<ProductsCart>();
}