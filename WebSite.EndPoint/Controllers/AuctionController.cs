using Application.IServices.CustomerServices.AuctionServices.Queries;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Areas.Seller.Models;

namespace WebSite.EndPoint.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IGetAllAuctionsService _getAllAuctionsService;

        public AuctionController(IGetAllAuctionsService getAllAuctionsService)
        {
            _getAllAuctionsService = getAllAuctionsService;
        }
        public async Task<IActionResult>  Index()
        {
            var dto = await _getAllAuctionsService.Execute();
            var model = dto.Select(a => new AuctionGetVM
            {
                Id = a.AuctionId,
                ProductId = a.ProductId,
                ProductName = a.ProductName,
                HighestPrice = a.HighestPrice,
                StartDeadTime = a.StartDeadTime,
                EndDeadTime = a.EndDeadTime,
                BasePrice=a.BasePrice,
                ImagesUrl = a.ImagesUrl,
                Availability = a.Availability,
                TotalPrice=a.TotalPrice,
                IsActive = a.IsActive
            }).ToList();
            return View(model);
        }

    }
}
