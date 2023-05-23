
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Models;


public class ProductsCart
{

    public int CartId { get; set; }

    public int ProductId { get; set; }

    public int? Quantity { get; set; }

  
}
