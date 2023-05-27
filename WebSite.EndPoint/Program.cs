using Application.Interfaces.Contexts;
using Application.IServices.Visitors;
using Application.Visitors.SaveVisitorInfo;
using Common.Mappers;
using Infrastructure.IdentityConfigs;
using Infrustracture.IdentityConfiguration;
using Persistence.Contexts.MongoContext;
using Persistence.Repositories.FacadeRepository;
using WebSite.EndPoint.Utilities.Filters;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region ContextAndIdentity
builder.Services.AddDbContextService(builder.Configuration);
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
builder.Services.AddTransient(typeof(ICustomMapper<,>), typeof(CustomMapper<,>));
builder.Services.AddScoped<IGeneralRepository, GeneralRepository>();
builder.Services.AddTransient  (typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
builder.Services.AddScoped<ISaveVisitorInfoService, SaveVisitorInfoService>();
builder.Services.AddScoped<SaveVisitorFilter>();
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

app.Run();
