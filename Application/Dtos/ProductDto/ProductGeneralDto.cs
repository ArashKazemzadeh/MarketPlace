﻿using ConsoleApp1.Models;

namespace Application.Dtos.ProductDto;

public class ProductGeneralDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? BasePrice { get; set; }
    public bool IsAuction { get; set; }
    public bool? IsConfirm { get; set; }
    public int? Availability { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public Auction Auction { get; set; }
    public ICollection<Image> Image { get; set; }
    public ICollection<Category> Categories { get; set; }
}