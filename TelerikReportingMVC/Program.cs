using Microsoft.Extensions.DependencyInjection.Extensions;
using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddNewtonsoftJson();

// Configure dependencies for ReportsController.
builder.Services.TryAddSingleton<IReportServiceConfiguration>(sp =>
    new ReportServiceConfiguration
    {
        // The default ReportingEngineConfiguration will be initialized from appsettings.json or appsettings.{EnvironmentName}.json:
        ReportingEngineConfiguration = sp.GetService<IConfiguration>(),
        // In case the ReportingEngineConfiguration needs to be loaded from a specific configuration file, use the approach below:
        //ReportingEngineConfiguration = ResolveSpecificReportingConfiguration(sp.GetService<IWebHostEnvironment>()),
        HostAppId = "ReportingNet6",
        Storage = new FileStorage(),
        ReportSourceResolver = new UriReportSourceResolver(Path.Combine(sp.GetRequiredService<IWebHostEnvironment>().ContentRootPath, "Reports"))
    });

builder.Services.AddCors(corsOption => corsOption.AddPolicy(
    "ReportingRestPolicy",
    corsBuilder =>
    {
        corsBuilder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    }
));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseCors("ReportingRestPolicy");

app.Run();
