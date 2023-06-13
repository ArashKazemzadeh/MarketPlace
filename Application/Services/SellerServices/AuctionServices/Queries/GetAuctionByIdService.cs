using Application.Dtos;
using Application.IServices.CustomerServices.AuctionServices.Queries;
using Application.IServices.SellerServices.AuctionServices.Queries;
using ConsoleApp.Models;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.SellerServices.AuctionServices.Queries
{
    public class GetAuctionByIdService: IGetAuctionByIdService
    {
        private readonly IAuctionRepository _auctionRepository;

        public GetAuctionByIdService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository; 
        }

        public async Task<GeneralDto<AuctionDto>> Execute(int id)
        {
            var auction = await _auctionRepository.GetByIdAsync(id);
            if (auction==null)
            {
                return new GeneralDto<AuctionDto>
                {
                    message = "مزایده موجود نیست."
                };
            }

            var result = new AuctionDto
            {
                Id = auction.Id,
                StartDeadTime = auction.StartDeadTime,
                EndDeadTime = auction.EndDeadTime,
                HighestPrice = auction.HighestPrice,
                Product = auction.Product,
                ProductId = auction.ProductId
            };
            return new GeneralDto<AuctionDto>
            {
                Data = result
            };
        }
    }
}
