namespace Domin.IRepositories.Dtos
{
    public class SellerUpdateRepositoryDto
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; } = false;
        public double CommissionPercentage { get; set; }

    }
}
