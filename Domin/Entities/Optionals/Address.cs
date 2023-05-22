using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public  class Address
{
    public int Id { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public string? Description { get; set; }

    public int? CustomerId { get; set; }
    public int? SellerId { get; set; }


    public virtual Customer? Customer { get; set; }

    public virtual Seller? Seller { get; set; }
}
