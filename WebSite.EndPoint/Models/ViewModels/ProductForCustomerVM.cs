namespace WebSite.EndPoint.Models.ViewModels
{
    public class ProductForCustomerVM
    {
        public string? Name { get; set; }
        public int? BasePrice { get; set; }
        public int? Availability { get; set; }
        public string? Description { get; set; }
        public int? Id { get; set; }
        public bool? IsActive { get; set; }

        public int? BoothId { get; set; }
        public string BoothName { get; set; }
        public List<string> ImagesUrls { get; set; }
        public List<string> Categories { get; set; }
    }
}
