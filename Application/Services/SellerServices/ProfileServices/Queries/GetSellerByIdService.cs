using Application.IServices.SellerServices.ProfileServices.Queries;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.SellerServices.ProfileServices.Queries
{
    public class GetSellerByIdService: IGetSellerByIdService
    {
        private readonly ISellerRepository _sellerRepository;

        public GetSellerByIdService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<AddSellerDto> Execute(int sellerId)
        {
            var seller = await _sellerRepository.GetByIdWithNavigationAsync(sellerId);
            return seller;

        }
    }
}
