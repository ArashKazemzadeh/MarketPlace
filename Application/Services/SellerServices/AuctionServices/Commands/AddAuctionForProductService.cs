using Application.IServices.SellerServices.AuctionServices.Commands;
using ConsoleApp.Models;
using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository;
namespace Application.Services.SellerServices.AuctionServices.Commands;



public class AddAuctionForProductService : IAddAuctionForProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IAuctionRepository _auctionRepository;

    public AddAuctionForProductService(IProductRepository productRepository,
        IAuctionRepository auctionRepository)
    {
        _productRepository = productRepository;
        _auctionRepository = auctionRepository;
    }

    public async Task<string> Execute(AuctionDto auctionDto, int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product == null)
        {
            return "کالایافت نشد.";
        }

        // Create a new Auction object
        var auction = new Auction
        {
            StartDeadTime = auctionDto.StartDeadTime,
            EndDeadTime = auctionDto.EndDeadTime,
            HighestPrice = auctionDto.HighestPrice,
            ProductId = productId,
            //Product = product
        };

        // Set the Auction property of the Product
        
        product.IsAuction = true;
        await _auctionRepository.AddAsync(auction);
        product.Auction = auction;
        // Update the product and add the auction to the repository
        await _productRepository.UpdateAsync(product);
    

        return "مزایده با موفقیت ایجاد شد.";

    }
}

