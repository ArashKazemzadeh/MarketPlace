using Application.IServices.AdminServices.ConfirmServices;
using Application.IServices.AdminServices.ProoductServices.Queries;
using Microsoft.AspNetCore.Mvc;
namespace WebSite.EndPoint.Areas.Admin.Controllers;



[Area("Admin")]
public class ConfirmController : Controller
{
    private readonly IGetProductsWithSellerNameAsyncService _getProductsWithSellerNameAsyncService;
    private readonly IConfirmForAddProductService _confirmForAddProductService;
    private readonly IGeAllCommentsByFalseConFirmService _allCommentsByFalseConFirmService;
    private readonly IConfirmForAddCommentService _confirmForAddCommentService;
    public ConfirmController(IGetProductsWithSellerNameAsyncService getProductsWithSellerNameAsyncService,
        IConfirmForAddProductService confirmForAddProductService, 
        IGeAllCommentsByFalseConFirmService allCommentsByFalseConFirmService,
        IConfirmForAddCommentService confirmForAddCommentService
        )                                                       
    {
        _getProductsWithSellerNameAsyncService = getProductsWithSellerNameAsyncService;
        _confirmForAddProductService = confirmForAddProductService;
        _confirmForAddCommentService = confirmForAddCommentService;
        _allCommentsByFalseConFirmService = allCommentsByFalseConFirmService;
    }
    [HttpGet]
    public async Task<IActionResult> InConfirmProducts()
    {
        var noConfirmProduct = await _getProductsWithSellerNameAsyncService.Execute();

        return View(noConfirmProduct);
    }
    [HttpPost]
    public async Task<IActionResult> ToConfirmingProduct(int porductId)
    {

       var result=await _confirmForAddProductService.Execute(porductId);
       ViewBag.Message = result.message;
        return RedirectToAction("InConfirmProducts");
    }
    [HttpGet]
    public async Task<IActionResult> InConfirmComments()
    {
        var noConfirmComment = await _allCommentsByFalseConFirmService.Execute();
        return View(noConfirmComment);
    }
    [HttpPost]
    public async Task<IActionResult> ToConfirmingComment(int commentId)
    {
        var result = await _confirmForAddCommentService.Execute(commentId);
        ViewBag.Message = result.message;
        return RedirectToAction("InConfirmComments");
    }
}

