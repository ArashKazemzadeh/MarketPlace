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
        var actionBySeller = await _auctionRepository.HasOwnedAction(userId, auctionId);
        if (actionBySeller)
            return "شما نمی توانید در مزایده ی کالای غرفه ی خود شرکت کنید.";
        var auctionByCustomer = await _bidRepository.HasPlacedBid(userId, auctionId);
        if (auctionByCustomer)
            return "شما قبلا در این مزایده شرکت کرده اید.";
        if (price == 0)
            return "با صفر ریال وجدانا؟ ";
        var auction = await _auctionRepository.GetByIdAsync(auctionId);
        if (auction == null)
            return "مزایده موجود نیست.";
        if (auction.EndDeadTime < DateTime.Now)
            return "زمان مزایده به اتمام رسیده است";
        if (auction.HighestPrice > price)
            return "مبلغ پیشنهادی باید از بالانریت پیشنهاد بیشتر باشد.";
        var BaseTotalPrice = auction.Product.Availability * auction.Product.BasePrice;
        if (BaseTotalPrice > price)
            return "مبلغ پیشنهادی باید از قیمت پایه کل بیشتر باشد.";
        var customer = await _customerRepository.GetByIdAsync(userId);
        if (customer == null)
            return "کاربر موجود نیست.";
        var bidDto = new BidRepDto
        {
            Price = price ,
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
        if (result == 0 )
            return "خطا هنگام ذخیره ی اطلاعات رخ داد";
        return "پیشنهاد با موفقیت ثبت شد.";
    }
}

