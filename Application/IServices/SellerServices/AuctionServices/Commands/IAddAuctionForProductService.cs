using Application.Dtos;
using ConsoleApp.Models;
namespace Application.IServices.SellerServices.AuctionServices.Commands;




    public interface IAddAuctionForProductService
    {
        Task<string> Execute(AuctionDto auctionDto, int productId);
    }

