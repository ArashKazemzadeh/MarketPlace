using Domin.IRepositories.IseparationRepository;
using Persistence.Contexts.SqlServer;
using Persistence.Repositories.Optionals;
using Persistence.Repositories.Orders;
using Persistence.Repositories.Users;

namespace Persistence.Repositories.FacadeRepository
{
    public class GeneralRepository : IGeneralRepository
    {
        private readonly DatabaseContext _context;
       

        public GeneralRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IAddressRepository  _AddressRepository;

        public IAddressRepository AddressRepository
        {
            get
            {
                return _AddressRepository = _AddressRepository ?? new AddressRepository(_context);
            }
        }
        public ICommentRepository _CommentRepository;
        public ICommentRepository CommentRepository
        {
            get
            {
                return _CommentRepository = _CommentRepository ?? new CommentRepository(_context);
            }
        }

        public IFileForUserRepository  _FileForUserRepository;
        public IFileForUserRepository FileForUserRepository
        {
            get
            {
                return _FileForUserRepository = _FileForUserRepository ?? new FileForUserRepository(_context);
            }
        }

        public IImageForProductRepository  _ImageForProductRepository;
        public IImageForProductRepository ImageForProductRepository
        {
            get
            {
                return _ImageForProductRepository = _ImageForProductRepository ?? new ImageForProductRepository(_context);
            }
        }

        public IMedalRepository   _MedalRepository;
        public IMedalRepository MedalRepository
        {
            get
            {
                return _MedalRepository = _MedalRepository ?? new MedalRepository(_context);
            }
        }

        public IAuctionRepository   _AuctionRepository;
        public IAuctionRepository AuctionRepository
        {
            get
            {
                return _AuctionRepository = _AuctionRepository ?? new AuctionRepository(_context);
            }
        }

        public IBidRepository   _BidRepository;
        public IBidRepository BidRepository
        {
            get
            {
                return _BidRepository = _BidRepository ?? new BidRepository(_context);
            }
        }

        public IBoothRepository   _BoothRepository;
        public IBoothRepository BoothRepository
        {
            get
            {
                return _BoothRepository = _BoothRepository ?? new BoothRepository(_context);
            }
        }

        public ICartRepository   _CartRepository;
        public ICartRepository CartRepository
        {
            get
            {
                return _CartRepository = _CartRepository ?? new CartRepository(_context);
            }
        }
        public ICategoryRepository   _CategoryRepository;
        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _CategoryRepository = _CategoryRepository ?? new CategoryRepository(_context);
            }
        }
        public IInvoiceRepository   _InvoiceRepository;
        public IInvoiceRepository InvoiceRepository
        {
            get
            {
                return _InvoiceRepository = _InvoiceRepository ?? new InvoiceRepository(_context);
            }
        }
        public IProductRepository   _ProductRepository;
        public IProductRepository ProductRepository
        {
            get
            {
                return _ProductRepository = _ProductRepository ?? new ProductRepository(_context);
            }
        }

        public IProductsCartRepository  _ProductsCartRepository;
        public IProductsCartRepository ProductsCartRepository
        {
            get
            {
                return _ProductsCartRepository = _ProductsCartRepository ?? new ProductsCartRepository(_context);
            }
        }

        public ICustomerRepository   _CustomerRepository;
        public ICustomerRepository CustomerRepository
        {
            get
            {
                return _CustomerRepository = _CustomerRepository ?? new CustomerRepository(_context);
            }
        }
        public ISellerRepository   _SellerRepository;
        public ISellerRepository SellerRepository
        {
            get
            {
                return _SellerRepository = _SellerRepository ?? new SellerRepository(_context);
            }
        }
    }
}
