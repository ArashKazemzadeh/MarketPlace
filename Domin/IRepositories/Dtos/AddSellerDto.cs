namespace Domin.IRepositories.Dtos
{
    public class AddSellerDto
    {
        public int SellerId { get; set; }
        public string? CompanyName { get; set; }
        public double CommissionPercentage { get; set; }
        public int AddressId { get; set; } //?
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? AddressDescription { get; set; }
        public int BoothId { get; set; }  //?
        public string? BoothName { get; set; }
        public string? BoothDescription { get; set; }
    }
}
