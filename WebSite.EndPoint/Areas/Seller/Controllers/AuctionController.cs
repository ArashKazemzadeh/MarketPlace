using Application.IServices.AdminServices.UserService.Commands;
using Application.IServices.CustomerServices.AuctionServices.Queries;
using Application.IServices.SellerServices.AuctionServices.Commands;
using Application.IServices.SellerServices.AuctionServices.Queries;
using ConsoleApp.Models;
using Domin.IRepositories.Dtos;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Areas.Seller.Models;

namespace WebSite.EndPoint.Areas.Seller.Controllers;


[Area("Seller")]
public class AuctionController : Controller
{

    private readonly IAddAuctionForProductService _addAuctionForProductService;
    private readonly IGetAllAuctionBySellerIdService _getAllAuctionBySellerIdService;
    private readonly IAccountService _accountService;
    public AuctionController(IAddAuctionForProductService addAuctionForProductService, IGetAllAuctionBySellerIdService getAllAuctionBySellerIdService, IAccountService accountService)
    {
        _addAuctionForProductService = addAuctionForProductService;
        _getAllAuctionBySellerIdService = getAllAuctionBySellerIdService;
        _accountService = accountService;
    }

    public async Task<IActionResult> Index()
    {
        var seller = await _accountService.GetLoggedInUserId();
        var SellerId = Convert.ToInt32(seller);
        var auctionsDto = await _getAllAuctionBySellerIdService.Execute(SellerId);
        var listAuctions = auctionsDto.Data.Select(a=>new AuctionGetVM
        {
            Id = a.AuctionId,
            StartDeadTime = a.StartDeadTime,
            EndDeadTime = a.EndDeadTime,
            HighestPrice = a.HighestPrice,
            ProductName = a.ProductName,
            ProductId = a.ProductId
        }).ToList();
        return View(listAuctions);
    }
    [HttpPost]
    public async Task<IActionResult> Create(AuctionAddVm model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var dto = new AuctionDto
        {
            StartDeadTime = model.StartDeadTime,
            EndDeadTime = model.EndDeadTime,
        };
     var i=   await _addAuctionForProductService.Execute(dto, model.ProductId);
     return RedirectToAction("Index");
    }

    public async Task<IActionResult> Create(int productId)
    {
        var sendId = new AuctionAddVm
        {
            ProductId = productId
        };
        return View(sendId);
    }
}


