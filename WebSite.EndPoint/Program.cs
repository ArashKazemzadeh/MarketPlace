using Application.IServices.AutoServices;
using Hangfire;
using Hangfire.SqlServer;
using Infrastructure.IdentityConfigs;
using Infrustracture.CookiesConfiguration;
using Infrustracture.IocConfiguration;
using WebSite.EndPoint.Utilities.Filters;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
#region Services
builder.Services.AddHttpContextAccessor();
builder.Services.AddIdentityDbContextService(builder.Configuration);
builder.Services.AddCookiesService(builder.Configuration);
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString(
        "sqlserver"), new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromSeconds(5),
        SlidingInvisibilityTimeout = TimeSpan.FromSeconds(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        DisableGlobalLocks = true
    }));
builder.Services.AddHangfireServer();

builder.Services.AddHangfireServer();
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
