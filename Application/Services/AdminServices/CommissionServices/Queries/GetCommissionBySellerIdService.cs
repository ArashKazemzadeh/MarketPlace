using Application.Dtos;
using Application.IServices.AdminServices.CommissionServices.Queries;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.AdminServices.CommissionServices.Queries
{
    public class GetCommissionBySellerIdService : IGetCommissionBySellerIdService
    {
        private readonly ISellerRepository _sellerRepository;

        public GetCommissionBySellerIdService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<GeneralDto> Execute(int id)
        {
            var seller = await _sellerRepository.GetByIdAsync(id);

            if (seller == null)
            {
                return new GeneralDto
                {
                    message = "این فروشنده موجود نیست"
                };
            }

            var commission = seller.CommissionsAmount;
            return new GeneralDto
            {
                message = "محاسبه انجام شد.",
                Amount = commission
            };
        }
    }

}
