using Application.Dtos.UserDto;
using Application.IServices.AdminServices.UserService.Queries;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.AdminServices.UserServices.SellerService.Queries
{
    public class GetAllSellerAdminService : IGetAllSellerAdminService
    {
        private readonly ISellerRepository _sellerRepository;

        public GetAllSellerAdminService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }
        public async Task<List<SellerDto>> Execute()
        {
            var existSellers = await _sellerRepository.GetAllAsync();
            List<SellerDto> sellerDtos = existSellers.Select(s => new SellerDto
            {
                Id = s.Id,
                CompanyName = s.CompanyName,
                CommissionsAmount = s.CommissionsAmount,
                CommissionPercentage = s.CommissionPercentage,
                SalesAmount = s.SalesAmount
            }).ToList();
            return sellerDtos;
        }
    }
}
