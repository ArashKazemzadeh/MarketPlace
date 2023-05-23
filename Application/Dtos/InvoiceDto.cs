

namespace ConsoleApp.Models;


public class InvoiceDto
{
    public int Id { get; set; }

    public int? CartId { get; set; }

    public string? PaymentInfo { get; set; }

    public int? TotalPrices { get; set; }

    public string? PaymentStatus { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? DeliveryDate { get; set; }
    
}
