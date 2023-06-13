using Infrastructure.IdentityConfigs;
using Infrustracture.IdentityConfiguration;
using Infrustracture.IocConfiguration;
using WebSite.EndPoint.Utilities.Filters;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
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



#region IOC
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<SaveVisitorFilter>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScopeSqlServerTables(builder.Configuration);
builder.Services.AddScopeMongoDbDocuments(builder.Configuration);
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
   app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areaAdmin",
        pattern: "{area:exists}/{controller=ForVisitor}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
