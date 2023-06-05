using Application.IServices.AdminServices.ConfirmServices;
using Application.IServices.AdminServices.ProoductServices.Queries;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Areas.Admin.Models;

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
 
    public async Task<IActionResult> InConfirmProducts()
    {
        var noConfirmProduct = await _getProductsWithSellerNameAsyncService.Execute();
        var viewModels = noConfirmProduct.Select(p => new ProductForConfirmVM
        {   
            Id=p.Id,
            Name = p.Name,
            Description = p.Description,
            BasePrice = p.BasePrice,
            Availability = p.Availability,
            SellerName = p.SellerName,
            IsConfirm = p.IsConfirm

        }).ToList();
        return View(viewModels);
    }
  
    public async Task<IActionResult> ToConfirmingProduct(int productId)
    {
        var result=await _confirmForAddProductService.Execute(productId);
        var noConfirmProduct = await _getProductsWithSellerNameAsyncService.Execute();

       
        return RedirectToAction("InConfirmProducts");
    }
 
    public async Task<IActionResult> InConfirmComments()
    {
        var noConfirmComment = await _allCommentsByFalseConFirmService.Execute();
     
        return View(noConfirmComment);
    }
   
    public async Task<IActionResult> ToConfirmingComment(int commentId)
    {
        var result = await _confirmForAddCommentService.Execute(commentId);
        return RedirectToAction("InConfirmComments");
    }
}

