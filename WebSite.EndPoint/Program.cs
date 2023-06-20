using Application.IServices.AutoServices;
using Hangfire;
using Infrastructure.IdentityConfigs;
using Infrustracture.appsettingConfiguration;
using Infrustracture.CookiesConfiguration;
using Infrustracture.HangFireConfiguration;
using Infrustracture.IocConfiguration;
using WebSite.EndPoint.Utilities.Filters;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


#region Services
builder.Services.AddHttpContextAccessor();
builder.Services.AddIdentityDbContextService(builder.Configuration);
builder.Services.AddCookiesService(builder.Configuration);
builder.Services.AddAppSettingService(builder.Configuration);
builder.Services.AddHangFireCustomService(builder.Configuration);


#endregion
#region IOC
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
#region HangFires
app.UseHangfireServer();
RecurringJob.AddOrUpdate<IProcessCompletedAuctionsAndAddToWinnerCart>
    ("Add product to winner of cart", x => x.Execute(), Cron.Minutely);
RecurringJob.AddOrUpdate<ICalculationOfSalesAndTheCommissionAmountOfEachSeller>
    ("Commission Calculation", x => x.Execute(), Cron.Minutely);
RecurringJob.AddOrUpdate<IAggregateCommissionsForAdmin>
    ("Total commission calculation site", x => x.Execute(), Cron.Minutely);
RecurringJob.AddOrUpdate<IAssignMedalToSeller>
    ("create medal for sellers", x => x.Execute(), Cron.Minutely);

#endregion
#region middlewares
app.UseHangfireDashboard();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
#endregion
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
