using Domin.Attributes;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;
[Auditable]

public class ImageForProduct
{
    public int Id { get; set; }

    public string? Url { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
