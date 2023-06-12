namespace Application.Dtos.ProductDto;

public class ProductForUpdateDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? BasePrice { get; set; }
 
    public int? Availability { get; set; }
    public string? Description { get; set; }
   

}