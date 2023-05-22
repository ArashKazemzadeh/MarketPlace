using Domin.Attributes;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;
[Auditable]

public class Customer
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
