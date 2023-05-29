using Application.Interfaces.Contexts;
using Application.IServices.AdminServices.ConfirmServices;
using Application.IServices.AdminServices.ProoductServices.Queries;
using Application.IServices.Visitors;
using Application.Services.AdminServices.CommentService.Command;
using Application.Services.AdminServices.CommentService.Query;
using Application.Services.AdminServices.ProoductServices.Commands;
using Application.Services.AdminServices.ProoductServices.Queries;
using Application.Services.Visitors.SaveVisitorInfo;
using Application.Visitors.SaveVisitorInfo;
using Common.Mappers;
using Domin.IRepositories.IseparationRepository;
using Infrastructure.IdentityConfigs;
using Infrustracture.IdentityConfiguration;
using Persistence.Contexts.MongoContext;
using Persistence.Repositories.FacadeRepository;
using Persistence.Repositories.Optionals;
using Persistence.Repositories.Orders;
using WebSite.EndPoint.Utilities.Filters;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region ContextAndIdentity
builder.Services.AddIdentityService(builder.Configuration);
builder.Services.ConfigureApplicationCookie(option =>
{
    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    option.LoginPath = "/account/login";
    option.AccessDeniedPath = "/Account/AccessDenied";
    option.SlidingExpiration = true;
});
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
#endregion

#region IOC
//-------------------------------Web Site----------------------------------

builder.Services.AddTransient(typeof(ICustomMapper<,>), typeof(CustomMapper<,>));
builder.Services.AddScoped<IGeneralRepository, GeneralRepository>();
builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
builder.Services.AddScoped<ISaveVisitorInfoService, SaveVisitorInfoService>();
builder.Services.AddScoped<SaveVisitorFilter>();
//-------------------------------Admin Area----------------------------------
builder.Services.AddTransient<IGetToDayReportService, GetToDayReportService>(); //دریافت گذارش های روزانه
builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IConfirmForAddProductService, ConfirmForAddProductService>();
builder.Services.AddScoped<IGetProductsWithSellerNameAsyncService, GetProductsWithSellerNameAsyncService>();
builder.Services.AddScoped<IGeAllCommentsByFalseConFirmService, GeAllCommentsByFalseConFirmService>();
builder.Services.AddScoped<IConfirmForAddCommentService, ConfirmForAddCommentService>();
builder.Services.AddScoped<ICommentRepository,CommentRepository>();
//builder.Services.AddScoped<>();

//---------------------------------------------------------------------------

#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapAreaControllerRoute(
    areaName: "Admin",
    name: "areas",
    pattern: "{area:exists}/{controller=ForVisitor}/{action=Index}/{id?}"
);
app.Run();
