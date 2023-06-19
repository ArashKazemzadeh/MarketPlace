using Domin.IRepositories.IseparationRepository;
using Hangfire;
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
builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage("sqlserver");
});
builder.Services.AddHangfireServer();
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

#region middlewares
// Use Hangfire 
app.UseHangfireDashboard("/hangfire");
app.UseHangfireServer();
RecurringJob.AddOrUpdate<IAutomaticTasksOfTheApplicationRepository>
    (x => x.ProcessCompletedAuctions(), Cron.MinuteInterval(1));
//--------------

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
