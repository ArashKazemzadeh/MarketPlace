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
using Infrustracture.IocConfiguration.IInterFaces;

namespace Infrustracture.IocConfiguration.Implimented
{
    public class ServicesConfigurationFacade : IServicesConfigurationFacade
    {
        private readonly IDeleteBoothAdminService _deleteBoothAdminService;
        private readonly IUpdateBoothAdminService _updateBoothAdminService;
        private readonly IGetAllBoothAdminService _getAllBoothAdminService;
        private readonly IGetBoothByIdService _getBoothByIdService;
        private readonly IGetAllCommissionsService _getAllCommissionsService;
        private readonly IGetCommissionBySellerIdService _getCommissionBySellerIdService;
        private readonly IConfirmForAddCommentService _confirmForAddCommentService;
        private readonly IConfirmForAddProductService _confirmForAddProductService;
        private readonly IAddMedalForSellerBySellerIdService _addMedalForSellerBySellerIdService;
        private readonly IDeleteProductAdminService _deleteProductAdminService;
        private readonly IUpdateProductAdminService _updateProductAdminService;
        private readonly IGetProductByBoothIdService _getProductByBoothIdService;
        private readonly IGetInvoiceByIdService _GetInvoiceByIdService;
        private readonly IGetSellersByCategoryId _GetSellersByCategoryId;
        private readonly IGetCustomerByIdService _GetCustomerByIdService;
        private readonly IUpdateCustomerByIdService _UpdateCustomerByIdService;
        private readonly IDeleteProductFromCartService _DeleteProductFromCartService;
        private readonly IAddProductToCartService _AddProductToCartService;
        private readonly IGetAllInvoicesService _GetAllInvoicesService;
        private readonly IGetAllAuctionsService _GetAllAuctionsService;
        private readonly IGetAuctionByIdService _GetAuctionByIdService;
        private readonly IAddBidForAuctionService _AddBidForAuctionService;
        private readonly IGetBoothWithSellerId _GetBoothWithSellerId;
        private readonly IAddCommentForProductService _AddCommentForProductService;
        private readonly IGetSellerByIdService _GetSellerByIdService;
        private readonly IUpdateSellerByIdService _UpdateSellerByIdService;
        private readonly IGetAllProductSellerService _GetAllProductSellerService;
        private readonly IFindByIdProductSellerService _FindByIdProductSellerService;
        private readonly IUpdateProductSellerService _UpdateProductSellerService;
        private readonly IDeleteProductSellerService _DeleteProductSellerService;
        private readonly IAddProductSellerService _AddProductSellerService;
        private readonly IAddAuctionForProductService _AddAuctionForProductService;
        private readonly IGetBoothProfileBySellerId _GetBoothProfileBySellerId;
        private readonly IDeleteImageForProductService _DeleteImageForProductService;
        private readonly IAddImageForProductService _AddImageForProductService;
        private readonly IGetAllAuctionBySellerIdService _GetAllAuctionBySellerIdService;
        private readonly IInActiveBoothSellerService _InActiveBoothSellerService;
        private readonly IUpdateBoothSellerService _UpdateBoothSellerService;
        private readonly IAddBoothSellerService _AddBoothSellerService;

        public ServicesConfigurationFacade(IDeleteBoothAdminService deleteBoothAdminService,
            IUpdateBoothAdminService updateBoothAdminService,
            IGetAllBoothAdminService getAllBoothAdminService,
            IGetBoothByIdService getBoothByIdService,
            IGetAllCommissionsService getAllCommissionsService,
            IGetCommissionBySellerIdService getCommissionBySellerIdService,
            IConfirmForAddCommentService confirmForAddCommentService,
            IConfirmForAddProductService confirmForAddProductService,
            IAddMedalForSellerBySellerIdService addMedalForSellerBySellerIdService,
            IDeleteProductAdminService deleteProductAdminService,
            IUpdateProductAdminService updateProductAdminService,
            IGetProductByBoothIdService getProductByBoothIdService,
            IGetInvoiceByIdService getInvoiceByIdService,
            IGetSellersByCategoryId getSellersByCategoryId,
            IGetCustomerByIdService getCustomerByIdService,
            IUpdateCustomerByIdService updateCustomerByIdService,
            IDeleteProductFromCartService deleteProductFromCartService,
            IAddProductToCartService addProductToCartService,
            IGetAllInvoicesService getAllInvoicesService,
            IGetAllAuctionsService getAllAuctionsService,
            IGetAuctionByIdService getAuctionByIdService,
            IAddBidForAuctionService addBidForAuctionService,
            IGetBoothWithSellerId getBoothWithSellerId,
            IAddCommentForProductService addCommentForProductService

            )
        {
            _deleteBoothAdminService = deleteBoothAdminService;
            _updateBoothAdminService = updateBoothAdminService;
            _getAllBoothAdminService = getAllBoothAdminService;
            _getBoothByIdService = getBoothByIdService;
            _getAllCommissionsService = getAllCommissionsService;
            _getCommissionBySellerIdService = getCommissionBySellerIdService;
            _confirmForAddCommentService = confirmForAddCommentService;
            _confirmForAddProductService = confirmForAddProductService;
            _addMedalForSellerBySellerIdService = addMedalForSellerBySellerIdService;
            _deleteProductAdminService = deleteProductAdminService;
            _updateProductAdminService = updateProductAdminService;
            _getProductByBoothIdService = getProductByBoothIdService;
            _GetInvoiceByIdService = getInvoiceByIdService;
            _GetSellersByCategoryId = getSellersByCategoryId;
            _GetCustomerByIdService = getCustomerByIdService;
            _UpdateCustomerByIdService = updateCustomerByIdService;
            _DeleteProductFromCartService = deleteProductFromCartService;
            _AddProductToCartService = addProductToCartService;
            _GetAllInvoicesService = getAllInvoicesService;
            _GetAllAuctionsService = getAllAuctionsService;
            _GetAuctionByIdService = getAuctionByIdService;
            _AddBidForAuctionService = addBidForAuctionService;
            _GetBoothWithSellerId = getBoothWithSellerId;
            _AddCommentForProductService = addCommentForProductService;
        }
        public IDeleteBoothAdminService DeleteBoothAdminService => _deleteBoothAdminService;
        public IUpdateBoothAdminService UpdateBoothAdminService => _updateBoothAdminService;
        public IGetAllBoothAdminService GetAllBoothAdminService => _getAllBoothAdminService;
        public IGetBoothByIdService GetBoothByIdService => _getBoothByIdService;
        public IGetAllCommissionsService GetAllCommissionsService => _getAllCommissionsService;
        public IGetCommissionBySellerIdService GetCommissionBySellerIdService => _getCommissionBySellerIdService;
        public IConfirmForAddCommentService ConfirmForAddCommentService => _confirmForAddCommentService;
        public IConfirmForAddProductService ConfirmForAddProductService => _confirmForAddProductService;
        public IAddMedalForSellerBySellerIdService AddMedalForSellerBySellerIdService => _addMedalForSellerBySellerIdService;
        public IDeleteProductAdminService DeleteProductAdminService => _deleteProductAdminService;
        public IUpdateProductAdminService UpdateProductAdminService => _updateProductAdminService;
        public IGetProductByBoothIdService GetProductByBoothIdService => _getProductByBoothIdService;
        public IGetAllInvoicesService GetAllInvoicesService => _GetAllInvoicesService;
        public IGetInvoiceByIdService GetInvoiceByIdService => _GetInvoiceByIdService;
        public IAddProductToCartService AddProductToCartService => _AddProductToCartService;
        public IDeleteProductFromCartService DeleteProductFromCartService => _DeleteProductFromCartService;
        public IUpdateCustomerByIdService UpdateCustomerByIdService => _UpdateCustomerByIdService;
        public IGetCustomerByIdService GetCustomerByIdService => _GetCustomerByIdService;
        public IGetSellersByCategoryId GetSellersByCategoryId => _GetSellersByCategoryId;
        public IGetAllAuctionsService GetAllAuctionsService => _GetAllAuctionsService;
        public IGetAuctionByIdService GetAuctionByIdService => _GetAuctionByIdService;
        public IAddBidForAuctionService AddBidForAuctionService => _AddBidForAuctionService;
        public IGetBoothWithSellerId GetBoothWithSellerId => _GetBoothWithSellerId;
        public IAddCommentForProductService AddCommentForProductService => _AddCommentForProductService;
        public IAddAuctionForProductService AddAuctionForProductService => _AddAuctionForProductService;
        public IGetAllAuctionBySellerIdService GetAllAuctionBySellerIdService => _GetAllAuctionBySellerIdService;
        public IAddBoothSellerService AddBoothSellerService => _AddBoothSellerService;
        public IInActiveBoothSellerService InActiveBoothSellerService => _InActiveBoothSellerService;
        public IUpdateBoothSellerService UpdateBoothSellerService => _UpdateBoothSellerService;
        public IGetBoothProfileBySellerId GetBoothProfileBySellerId => _GetBoothProfileBySellerId;
        public IAddImageForProductService AddImageForProductService => _AddImageForProductService;
        public IDeleteImageForProductService DeleteImageForProductService => _DeleteImageForProductService;
        public IAddProductSellerService AddProductSellerService => _AddProductSellerService;
        public IDeleteProductSellerService DeleteProductSellerService => _DeleteProductSellerService;
        public IUpdateProductSellerService UpdateProductSellerService => _UpdateProductSellerService;
        public IFindByIdProductSellerService FindByIdProductSellerService => _FindByIdProductSellerService;
        public IGetAllProductSellerService GetAllProductSellerService => _GetAllProductSellerService;
        public IUpdateSellerByIdService UpdateSellerByIdService => _UpdateSellerByIdService;
        public IGetSellerByIdService GetSellerByIdService => _GetSellerByIdService;
    }
}

