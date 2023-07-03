using Application.IServices.CustomerServices.BidServices.Commands;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.Dtos.Bid;
using Domin.IRepositories.IseparationRepository.SqlServer;

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
    public async Task<string> Execute(int userId, int auctionId, int price)
    {
        var auction = await _auctionRepository.GetByIdAsync(auctionId);
        var customer = await _customerRepository.GetByIdAsync(userId);
        var actionByCustomer = await _bidRepository.HasPlacedBid(userId, auctionId);
        if (auction == null)
            return "مزایده موجود نیست.";
        if (customer == null)
            return "کاربر موجود نیست.";
        if (auction.EndDeadTime < DateTime.Now)
            return "زمان مزایده به اتمام رسیده است";
        if (actionByCustomer)
            return "شما قبلا در این مزایده شرکت کرده اید.";
        var bidDto = new BidRepDto
        {
            Price = price,
            RegisterDate = DateTime.Now,
            AuctionId = auction.Id,
            Customer = customer,
            Auction = auction,
        };


        if (price > auction.HighestPrice)
        {
            auction.HighestPrice = price;
            await _auctionRepository.UpdateAsync(auction);
        }
        else
            return "قیمت پیشنهادی باید از اخرین مبلغ پیشنهادی بیشتر باشد.";
        var result = await _bidRepository.AddAsync(bidDto);//+
        //var result2 = await _auctionRepository.UpdateWithBidAsync(auction, bidDto);
        //var result3 = await _customerRepository.UpdateWithBidAsync(customer, bidDto);
        if (result == 0 )
        {
            return "خطا هنگام ذخیره ی اطلاعات رخ داد";
        }
        return "پیشنهاد با موفقیت ثبت شد.";
    }

}

