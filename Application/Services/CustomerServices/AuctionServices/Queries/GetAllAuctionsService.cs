using Application.IServices.CustomerServices.AuctionServices.Queries;
using Domin.IRepositories.Dtos.Auction;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.CustomerServices.AuctionServices.Queries;

public class GetAllAuctionsService : IGetAllAuctionsService
{

    private readonly IAuctionRepository _auctionRepository;

    public GetAllAuctionsService(IAuctionRepository auctionRepository)
    {
        _auctionRepository = auctionRepository;
    }

    public async Task<List<AuctionProductDto>> Execute()
    {
        var auctions = await _auctionRepository.GetAllTrueAsync();
        if (auctions==null || auctions.Count==0)
        {
            return new List<AuctionProductDto>();
        }
     
        return auctions;
    }
}

