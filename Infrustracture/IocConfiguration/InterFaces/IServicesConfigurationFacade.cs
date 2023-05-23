using Application.IServices.AdminServices.BoothServices.Commands;
using Application.IServices.AdminServices.BoothServices.Queries;
using Application.IServices.AdminServices.CommissionServices.Queries;
using Application.IServices.AdminServices.ConfirmServices;
using Application.IServices.AdminServices.MedalServices.Commands;
using Application.IServices.AdminServices.ProoductServices.Commands;
using Application.IServices.AdminServices.ProoductServices.Queries;
using Application.IServices.CustomerServices.AuctionServices.Queries;
using Application.IServices.CustomerServices.BidServices.Commands;
using Application.IServices.CustomerServices.BoothServices.Commands;
using Application.IServices.CustomerServices.CommentServices.Commands;
using Application.IServices.CustomerServices.InvoiceServices.Queries;
using Application.IServices.CustomerServices.ProductServices.Commands;
using Application.IServices.CustomerServices.ProfileServices.Commands;
using Application.IServices.CustomerServices.ProfileServices.Queries;
using Application.IServices.CustomerServices.SellerServices.Queries;
using Application.IServices.SellerServices.AuctionServices.Commands;
using Application.IServices.SellerServices.AuctionServices.Queries;
using Application.IServices.SellerServices.BoothServices.Commands;
using Application.IServices.SellerServices.BoothServices.Queries;
using Application.IServices.SellerServices.ImageServices.Commands;
using Application.IServices.SellerServices.ProductServices.Commands;
using Application.IServices.SellerServices.ProductServices.Queries;
using Application.IServices.SellerServices.ProfileServices.Commands;
using Application.IServices.SellerServices.ProfileServices.Queries;

namespace Infrustracture.IocConfiguration.IInterFaces;

public interface IServicesConfigurationFacade
{
    #region AdminFile

    IDeleteBoothAdminService DeleteBoothAdminService { get; }
    IUpdateBoothAdminService UpdateBoothAdminService { get; }
    IGetAllBoothAdminService GetAllBoothAdminService { get; }
    IGetBoothByIdService GetBoothByIdService { get; }
    IGetAllCommissionsService GetAllCommissionsService { get; }
    IGetCommissionBySellerIdService GetCommissionBySellerIdService { get; }
    IConfirmForAddCommentService ConfirmForAddCommentService { get; }
    IConfirmForAddProductService ConfirmForAddProductService { get; }
    IAddMedalForSellerBySellerIdService AddMedalForSellerBySellerIdService { get; }
    IDeleteProductAdminService DeleteProductAdminService { get; }
    IUpdateProductAdminService UpdateProductAdminService { get; }
    IGetProductByBoothIdService GetProductByBoothIdService { get; }


    #endregion
    #region CustomerFile

    IGetAllInvoicesService GetAllInvoicesService { get; }
    IGetInvoiceByIdService GetInvoiceByIdService { get; }
    IAddProductToCartService AddProductToCartService { get; }
    IDeleteProductFromCartService DeleteProductFromCartService { get; }
    IUpdateCustomerByIdService UpdateCustomerByIdService { get; }
    IGetCustomerByIdService GetCustomerByIdService { get; }
    IGetSellersByCategoryId GetSellersByCategoryId { get; }
    IGetAllAuctionsService GetAllAuctionsService { get; }
    IGetAuctionByIdService GetAuctionByIdService { get; }
    IAddBidForAuctionService AddBidForAuctionService { get; }
    IGetBoothWithSellerId GetBoothWithSellerId { get; }
    IAddCommentForProductService AddCommentForProductService { get; }
    #endregion
    #region SellerFile

    IAddAuctionForProductService AddAuctionForProductService { get; }
    IGetAllAuctionBySellerIdService GetAllAuctionBySellerIdService { get; }
    IAddBoothSellerService AddBoothSellerService { get; }
    IInActiveBoothSellerService InActiveBoothSellerService { get; }
    IUpdateBoothSellerService UpdateBoothSellerService { get; }
    IGetBoothProfileBySellerId GetBoothProfileBySellerId { get; }
    IAddImageForProductService AddImageForProductService { get; }
    IDeleteImageForProductService DeleteImageForProductService { get; }
    IAddProductSellerService AddProductSellerService { get; }
    IDeleteProductSellerService DeleteProductSellerService { get; }
    IUpdateProductSellerService UpdateProductSellerService { get; }
    IFindByIdProductSellerService FindByIdProductSellerService { get; }
    IGetAllProductSellerService GetAllProductSellerService { get; }
    IUpdateSellerByIdService UpdateSellerByIdService { get; }
    IGetSellerByIdService GetSellerByIdService { get; }
    #endregion
}