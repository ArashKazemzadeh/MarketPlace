using Application.IServices.AdminServices.UserService.Commands;
using Application.IServices.CustomerServices.AuctionServices.Queries;
using Application.IServices.SellerServices.AuctionServices.Commands;
using Application.IServices.SellerServices.AuctionServices.Queries;
using Common;
using ConsoleApp.Models;
using Domin.IRepositories.Dtos;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Areas.Seller.Models;
namespace WebSite.EndPoint.Areas.Seller.Controllers;


[Area("Seller")]
[Authorize(Roles = "Seller")]
public class AuctionController : Controller
{

    private readonly IAddAuctionForProductService _addAuctionForProductService;
    private readonly IGetAllAuctionBySellerIdService _getAllAuctionBySellerIdService;
    private readonly IAccountService _accountService;
    private readonly IConfiguration _configuration;
 
    public AuctionController(
        IAddAuctionForProductService addAuctionForProductService,
        IGetAllAuctionBySellerIdService getAllAuctionBySellerIdService,
        IAccountService accountService, IConfiguration configuration
    )
    {
        _addAuctionForProductService = addAuctionForProductService;
        _getAllAuctionBySellerIdService = getAllAuctionBySellerIdService;
        _accountService = accountService;
        _configuration = configuration;
       
    }


   
    public async Task<IActionResult> Index()
    {

        var seller = await _accountService.GetLoggedInUserId();
       
        var SellerId = Convert.ToInt32(seller);
        var auctionsDto = await _getAllAuctionBySellerIdService.Execute(SellerId);
        var listAuctions = auctionsDto.Data.Select(a => new AuctionGetVM
        {
            Id = a.AuctionId,
            StartDeadTime = a.StartDeadTime,
            EndDeadTime = a.EndDeadTime,
            HighestPrice = a.HighestPrice,
            ProductName = a.ProductName,
            ProductId = a.ProductId
        }).ToList();
      ViewBag.Message=  TempData["CreateAuction"];
        return View(listAuctions);


    }
 
    [HttpPost]  
    public async Task<IActionResult> Create(AuctionAddVm model)
    {
        if (!ModelState.IsValid)
        {
            TempData.SetDateAppSettingValues(_configuration);
            return View(model);
        }
     
        var action = new AuctionDto
        {
            ProductId = model.ProductId,
            StartDeadTime = new DateTime(
                model.YearStartSelected,
                DateConvert.GetPersianMonthNumber(model.MonthStartSelected),
                model.DayStartSelected, model.HourStartSelected,
                model.MinuteStartSelected, 0, DateTimeKind.Local),
            EndDeadTime = new DateTime(model.YearEndSelected,
                DateConvert.GetPersianMonthNumber(model.MonthEndSelected),
                model.DayEndSelected, model.HourEndSelected, model.MinuteEndSelected,
                0, DateTimeKind.Local)
        };

        var result = await _addAuctionForProductService.Execute(action);
        if (result== "مزایده با موفقیت ایجاد شد")
        {
            TempData["CreateAuction"] = result;
            return RedirectToAction("Index");
        }
        ViewBag.Message = result;

        return View(model);
    }


    public async Task<IActionResult> Create(int productId)
    {

        TempData.SetDateAppSettingValues(_configuration);

        var sendId = new AuctionAddVm
        {
            ProductId = productId

        };
        return View(sendId);
    }
    

}


