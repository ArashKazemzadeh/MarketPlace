using Application.Dtos;
using Application.IServices.SellerServices.AuctionServices.Queries;
using Domin.IRepositories.Dtos.Auction;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.SellerServices.AuctionServices.Queries
{
    public class GetAllAuctionBySellerIdService : IGetAllAuctionBySellerIdService
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IProductRepository _productRepository;

        public GetAllAuctionBySellerIdService(
            ISellerRepository sellerRepository, IProductRepository productRepository)
        {
            _sellerRepository = sellerRepository;
            _productRepository = productRepository;
        }
        public async Task<GeneralDto<List<AuctionProductDto>>> Execute(int sellerId)
        {
            var seller = await _sellerRepository.GetByIdAsync(sellerId);
            if (seller==null)
            {
                return new GeneralDto<List<AuctionProductDto>> { message = "فروشنده یافت نشد"};
            }

        var result=    await _productRepository.GetProductsWithTrueAuctions(seller.Id);
        return new GeneralDto<List<AuctionProductDto>>
        {
            Data = result,
            message = "لیست کاملی از کالاها همراه با زمان اغاز و پایان مزایده"
        };
        }
    }
}
