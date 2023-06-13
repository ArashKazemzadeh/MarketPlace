using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Application.Interfaces.Contexts;
using Application.IServices.AdminServices.BoothServices.Commands;
using Application.IServices.AdminServices.BoothServices.Queries;
using Application.IServices.AdminServices.ConfirmServices;
using Application.IServices.AdminServices.ProoductServices.Commands;
using Application.IServices.AdminServices.ProoductServices.Queries;
using Application.IServices.AdminServices.UserService.Commands;
using Application.IServices.AdminServices.UserService.Queries;
using Application.IServices.Visitors;
using Application.Services.AdminServices.BoothServices.Commands;
using Application.Services.AdminServices.BoothServices.Queries;
using Application.Services.AdminServices.CommentService.Command;
using Application.Services.AdminServices.CommentService.Query;
using Application.Services.AdminServices.ProoductServices.Commands;
using Application.Services.AdminServices.ProoductServices.Queries;
using Application.Services.Visitors.SaveVisitorInfo;
using Application.Visitors.SaveVisitorInfo;
using Domin.IRepositories.IseparationRepository;
using Persistence.Contexts.MongoContext;
using Persistence.Repositories.FacadeRepository;
using Persistence.Repositories.Optionals;
using Persistence.Repositories.Orders;
using Persistence.Repositories.Users;
using Application.IServices.AdminServices.CommissionServices.Queries;
using Application.IServices.CustomerServices.AuctionServices.Queries;
using Application.IServices.SellerServices.AuctionServices.Commands;
using Application.IServices.SellerServices.AuctionServices.Queries;
using Application.IServices.SellerServices.ProfileServices.Commands;
using Application.Services.AdminServices.CommissionServices.Queries;
using Application.Services.AdminServices.UserServices.SellerService.Queries;
using Application.Services.AdminServices.UserServices.SellerService.Commands;
using Application.Services.AdminServices.UserServices.AllUserService;
using Application.Services.SellerServices.ProfileServices.Commands;
using Application.IServices.SellerServices.ProfileServices.Queries;
using Application.Services.SellerServices.ProfileServices.Queries;
using Application.IServices.SellerServices.ProductServices.Commands;
using Application.IServices.SellerServices.ProductServices.Queries;
using Application.Services.SellerServices.ProductServices.Commands;
using Application.Services.SellerServices.ProductServices.Queries;
using Application.IServices.SellerServices.ImageServices.Commands;
using Application.Services.SellerServices.ImageServices.Queries;
using Application.IServices.SellerServices.ImageServices.Queries;
using Application.Services.SellerServices.AuctionServices.Commands;
using Application.Services.SellerServices.AuctionServices.Queries;
using Application.Services.SellerServices.ImageServices.Commands;

namespace Infrustracture.IocConfiguration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddScopeSqlServerTables(this IServiceCollection services,
            IConfiguration configuration)
        {
            // ---------------------Admin-----------------------------------------------------------
            services.AddScoped<IGeneralRepository, GeneralRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IConfirmForAddProductService, ConfirmForAddProductService>();
            services.AddScoped<IGetProductsWithSellerNameAsyncService, GetProductsWithSellerNameAsyncService>();
            services.AddScoped<IGeAllCommentsConFirmService, GeAllCommentsConFirmService>();
            services.AddScoped<IConfirmForAddCommentService, ConfirmForAddCommentService>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IGetAllSellerAdminService, GetAllSellerAdminService>();
            services.AddScoped<IUpdateProductAdminService, UpdateProductAdminService>();
            services.AddScoped<IDeleteProductAdminService, DeleteProductAdminService>();
            services.AddScoped<IGetProductByIdService, GetProductByIdService>();
            services.AddScoped<IGetAllBoothAdminService, GetAllBoothAdminService>();
            services.AddScoped<IBoothRepository, BoothRepository>();
            services.AddScoped<IGetBoothByIdService, GetBoothByIdService>();
            services.AddScoped<IDeleteBoothAdminService, DeleteBoothAdminService>();
            services.AddScoped<IUpdateBoothAdminService, UpdateBoothAdminService>();
            services.AddScoped<IDeleteSellerByIdAdminService, DeleteSellerByIdAdminService>();
            services.AddScoped<IUpdateSellerAdminService, UpdateSellerAdminService>();
            services.AddScoped<IGetSellerByIdAdminService, GetSellerByIdAdminService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddUserIdToCustomerForRegisterService, AddUserIdToCustomerForRegisterService>();
            services.AddScoped<IGetAllCommissionsService, GetAllCommissionsService>();
            services.AddScoped<IIdentityRoleService, IdentityRoleService>();
            // ---------------------seller-----------------------------------------------------------
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IImageForProductRepository, ImageForProductRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddSellerService, AddSellerService>();
            services.AddScoped<IUpdateSellerByIdService, UpdateSellerByIdService>();
            services.AddScoped<IGetSellerByIdService, GetSellerByIdService>();
            services.AddScoped<IAddProductTooBoothSellerService, AddProductTooBoothSellerService>();
            services.AddScoped<IGetProductSellerService, GetProductSellerService>();
            services.AddScoped<IUpdateProductSellerService, UpdateProductSellerService>();
            services.AddScoped<IProductImageQueriesService, ProductImageQueriesService>();
            services.AddScoped<IDeleteProductSellerService, DeleteProductSellerService>();
            services.AddScoped<IProductImageCommandsService, ProductImageCommandsService>();
            services.AddScoped<IAddAuctionForProductService, AddAuctionForProductService>();
            services.AddScoped<IGetAllAuctionBySellerIdService, GetAllAuctionBySellerIdService>();
            services.AddScoped<IAuctionRepository, AuctionRepository>();
            return services;
        }
        public static IServiceCollection AddScopeMongoDbDocuments(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
            services.AddScoped<ISaveVisitorInfoService, SaveVisitorInfoService>();
            services.AddTransient<IGetToDayReportService, GetToDayReportService>();
            services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
            return services;
        }
    }
}
