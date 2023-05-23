using Persistence.Repositories.Optionals;
using Persistence.Repositories.Orders;
using Persistence.Repositories.Users;

namespace Persistence.Repositories.FacadeRepository
{
    public class GeneralRepository : IGeneralRepository
    {
        private readonly IAddressRepository _AddressRepository;
        private readonly ISellerRepository _SellerRepository;
        private readonly ICustomerRepository _CustomerRepository;
        private readonly IProductsCartRepository _ProductsCartRepository;
        private readonly IProductRepository _ProductRepository;
        private readonly IInvoiceRepository _InvoiceRepository;
        private readonly ICategoryRepository _CategoryRepository;
        private readonly ICartRepository _CartRepository;
        private readonly IBoothRepository _BoothRepository;
        private readonly IBidRepository _BidRepository;
        private readonly IAuctionRepository _AuctionRepository;
        private readonly IMedalRepository _MedalRepository;
        private readonly ICommentRepository _CommentRepository;
        private readonly IFileForUserRepository _FileForUserRepository;
        private readonly IImageForProductRepository _ImageForProductRepository;

        public GeneralRepository(IAddressRepository addressRepository,
            ISellerRepository sellerRepository,
        ICustomerRepository customerRepository,
        IProductsCartRepository productsCartRepository,
        IProductRepository productRepository,
        IInvoiceRepository invoiceRepository,
        ICategoryRepository categoryRepository,
        ICartRepository cartRepository,
        IBoothRepository boothRepository,
        IBidRepository bidRepository,
        IAuctionRepository auctionRepository,
        IMedalRepository medalRepository,
        ICommentRepository commentRepository,
        IFileForUserRepository fileForUserRepository,
        IImageForProductRepository imageForProductRepository)
        {
            _AddressRepository = addressRepository;
            _SellerRepository = sellerRepository;
            _CustomerRepository = customerRepository;
            _ProductsCartRepository = productsCartRepository;
            _ProductRepository = productRepository;
            _InvoiceRepository = invoiceRepository;
            _CategoryRepository = categoryRepository;
            _CartRepository = cartRepository;
            _BoothRepository = boothRepository;
            _BidRepository = bidRepository;
            _AuctionRepository = auctionRepository;
            _MedalRepository = medalRepository;
            _CommentRepository = commentRepository;
            _FileForUserRepository = fileForUserRepository;
            _ImageForProductRepository = imageForProductRepository;
        }

        public IAddressRepository AddressRepository => _AddressRepository;

        public ICommentRepository CommentRepository => _CommentRepository;

        public IFileForUserRepository FileForUserRepository => _FileForUserRepository;

        public IImageForProductRepository ImageForProductRepository => _ImageForProductRepository;

        public IMedalRepository MedalRepository => _MedalRepository;

        public IAuctionRepository AuctionRepository => _AuctionRepository;

        public IBidRepository BidRepository => _BidRepository;

        public IBoothRepository BoothRepository => _BoothRepository;

        public ICartRepository CartRepository => _CartRepository;

        public ICategoryRepository CategoryRepository => _CategoryRepository;

        public IInvoiceRepository InvoiceRepository => _InvoiceRepository;

        public IProductRepository ProductRepository => _ProductRepository;

        public IProductsCartRepository ProductsCartRepository => _ProductsCartRepository;

        public ICustomerRepository CustomerRepository => _CustomerRepository;

        public ISellerRepository SellerRepository => _SellerRepository;
    }
}
