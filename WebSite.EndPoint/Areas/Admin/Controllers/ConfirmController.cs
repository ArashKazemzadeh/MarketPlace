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
    private readonly IGeAllCommentsConFirmService _allCommentsConFirmService;
    private readonly IConfirmForAddCommentService _confirmForAddCommentService;
    public ConfirmController(IGetProductsWithSellerNameAsyncService getProductsWithSellerNameAsyncService,
        IConfirmForAddProductService confirmForAddProductService,
        IGeAllCommentsConFirmService allCommentsByFalseConFirmService,
        IConfirmForAddCommentService confirmForAddCommentService
        )
    {
        _getProductsWithSellerNameAsyncService = getProductsWithSellerNameAsyncService;
        _confirmForAddProductService = confirmForAddProductService;
        _confirmForAddCommentService = confirmForAddCommentService;
        _allCommentsConFirmService = allCommentsByFalseConFirmService;
    }

    public async Task<IActionResult> ConfirmProducts()
    {
        var noConfirmProduct = await _getProductsWithSellerNameAsyncService.Execute();
        var viewModels = noConfirmProduct.Select(p => new ProductForConfirmVM
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            BasePrice = p.BasePrice,
            Availability = p.Availability,
            SellerName = p.SellerName,
            IsConfirm = p.IsConfirm

        }).ToList();
        return View(viewModels);
    }

    public async Task<IActionResult> ConfirmingTrueProduct(int productId)
    {
        var result = await _confirmForAddProductService.ExecuteTrue(productId);
        return RedirectToAction("ConfirmProducts");
    }
    public async Task<IActionResult> ConfirmingFalseProduct(int productId)
    {
        var result = await _confirmForAddProductService.ExecuteFalse(productId);
        return RedirectToAction("ConfirmProducts");
    }

    public async Task<IActionResult> ConfirmComments()
    {
        var noConfirmComment = await _allCommentsConFirmService.Execute();
        return View(noConfirmComment);
    }

    public async Task<IActionResult> ConfirmingTrueComment(int commentId)
    {
        var result = await _confirmForAddCommentService.ExecuteTrue(commentId);
        return RedirectToAction("ConfirmComments");
    }
    public async Task<IActionResult> ConfirmingFalseComment(int commentId)
    {
        var result = await _confirmForAddCommentService.ExecuteFalse(commentId);
        return RedirectToAction("ConfirmComments");
    }
}

