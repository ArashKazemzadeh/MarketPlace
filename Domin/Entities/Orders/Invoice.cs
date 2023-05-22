using Domin.Attributes;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;
[Auditable]

public class Invoice
{
    public int Id { get; set; }

    public int? CartId { get; set; }

    public string? PaymentInfo { get; set; }

    public int? TotalPrices { get; set; }

    public string? PaymentStatus { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public virtual Cart? Cart { get; set; }
}
