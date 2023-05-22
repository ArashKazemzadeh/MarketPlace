
using Infrastructure.IdentityConfigs;
using Infrustracture.IdentityConfiguration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region Context
builder.Services.AddDbContextService(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);
//builder.Services.ConfigureApplicationCookie(option =>
//{
//    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
//    option.LoginPath = "/account/login";
//    option.AccessDeniedPath = "/Account/AccessDenied";
//    option.SlidingExpiration = true;
//});
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