using Application.Dtos;
using Application.IServices.SellerServices.ProfileServices.Queries;
using Domin.IRepositories.Dtos.Seller;
using Domin.IRepositories.IseparationRepository.Dapper;

namespace Application.Services.SellerServices.ProfileServices.Queries
{
    public class GetFinancialBySellerId: IGetFinancialBySellerId
    {
        private readonly IUserDapperRepository _userDapperRepository;

        public GetFinancialBySellerId(IUserDapperRepository userDapperRepository)
        {
            _userDapperRepository = userDapperRepository;
        }
        public async Task<GeneralDto<FinancialRepSeller>> Execute(int sellerId)
        {
            var seller = await _userDapperRepository.GetFinancialBySellerId(sellerId);
            if (seller==null)
            {
                return new GeneralDto<FinancialRepSeller>()
                {
                    message = "فروشنده یافت نشد",
                    Data = new FinancialRepSeller()
                };
            }

            return new GeneralDto<FinancialRepSeller>()
            {
                message = "200",
                Data=seller
            };

        }
    }
}
