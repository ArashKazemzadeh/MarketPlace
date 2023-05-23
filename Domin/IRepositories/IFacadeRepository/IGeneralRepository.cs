using Persistence.Repositories.Optionals;
using Persistence.Repositories.Orders;
using Persistence.Repositories.Users;

namespace Persistence.Repositories.FacadeRepository;

public interface IGeneralRepository
{
    IAddressRepository AddressRepository { get; }
    ICommentRepository CommentRepository { get; }
    IFileForUserRepository FileForUserRepository { get; }
    IImageForProductRepository ImageForProductRepository { get; }
    IMedalRepository MedalRepository { get; }
    IAuctionRepository AuctionRepository { get; }
    IBidRepository BidRepository { get; }
    IBoothRepository BoothRepository { get; }
    ICartRepository CartRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IInvoiceRepository InvoiceRepository { get; }
    IProductRepository ProductRepository { get; }
    IProductsCartRepository ProductsCartRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    ISellerRepository SellerRepository { get; }
}