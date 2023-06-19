using Application.IServices.CustomerServices.BidServices.Commands;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository;
namespace Application.Services.CustomerServices.BidServices.Commands;

public class AddBidForAuctionService : IAddBidForAuctionService
{
    private readonly IBidRepository _bidRepository;
    private readonly IAuctionRepository _auctionRepository;
    private readonly ICustomerRepository _customerRepository;
    public AddBidForAuctionService(IBidRepository bidRepository,
        IAuctionRepository auctionRepository, ICustomerRepository customerRepository)
    {
        _bidRepository = bidRepository;
        _auctionRepository = auctionRepository;
        _customerRepository = customerRepository;
    }
    public async Task<bool> Execute(int userId, int auctionId, int price)
    {
        var auction = await _auctionRepository.GetByIdAsync(auctionId);
        var customer = await _customerRepository.GetByIdAsync(userId);
        if (auction == null)
            return false;
        if (customer == null)
            return false;
        if (auction.EndDeadTime > DateTime.Now)
            return false;
        if (price > auction.HighestPrice)
            auction.HighestPrice = price;

        var bidDto = new BidRepDto
        {
            Price = price,
            RegisterDate = DateTime.Now,
            AuctionId = auction.Id,
            Customer = customer,
            Auction = auction,
        };
        await _bidRepository.AddAsync(bidDto);
        await _auctionRepository.UpdateWithBidAsync(auction, bidDto);
        await _customerRepository.UpdateWithBidAsync(customer, bidDto);
        return true;
    }

}

