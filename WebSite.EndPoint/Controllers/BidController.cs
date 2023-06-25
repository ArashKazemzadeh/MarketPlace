using Application.IServices.AdminServices.UserService.Commands;
using Application.IServices.CustomerServices.BidServices.Commands;
using Application.IServices.CustomerServices.BidServices.Queries;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Models.ViewModels;
using WebSite.EndPoint.Models.ViewModels.Bids;

namespace WebSite.EndPoint.Controllers
{
    public class BidController : Controller
    {
        private readonly IAddBidForAuctionService _addBidForAuctionService;
        private readonly IAccountService _accountService;
        private readonly IBidCustomerQueryServise _bidCustomerQueryServise;
        public BidController(IAddBidForAuctionService addBidForAuctionService,
            IAccountService accountService, IBidCustomerQueryServise bidCustomerQueryServise)
        {
            _addBidForAuctionService = addBidForAuctionService;
            _accountService = accountService;
            _bidCustomerQueryServise = bidCustomerQueryServise;
        }
        [HttpPost]
        public async Task<IActionResult> AddBid(BidAddVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var userId = await _accountService.GetLoggedInUserId();
            bool success = await _addBidForAuctionService.Execute(Convert.ToInt32(userId) , model.AuctionId, model.Price);
            if (!success)
            {
                ViewBag.Error = "فرایند ثبت با مشکل مواجه شد. لطفا شرایط مزایده را مجددا بررسی نمایید.";
                return View(model);
            }
            return RedirectToAction("MyBids");
        }
        public async Task<IActionResult> MyBids()
        {
            var userId = await _accountService.GetLoggedInUserId();
           var dto=await _bidCustomerQueryServise.GetCustomerBids(Convert.ToInt32(userId));
           var model =  dto.Select(b => new BidGetVm
           {
               Id = b.Id,
               Price = b.Price,
               RegisterDate = b.RegisterDate,
               IsAccepted = b.IsAccepted,
               AuctionId = b.AuctionId,
               EndDateAuction = b.EndDateAuction,
               StartDateAuction = b.StartDateAuction,
           }).ToList();
           return View(model);
        }
    }
}
