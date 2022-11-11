
using ApartmentManagement.Application.GlobalExceptionsLogs;
using ApartmentManagement.Application.Registirations;
using ApartmentManagement.Persistence.Registirations;
using ApartmentManagement.Persistence.SeedData;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.RegistrationServicePersistence(builder.Configuration);
builder.Services.RegistrationServiceApplication();
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddControllersWithViews().AddFluentValidation();


builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "ApartmentManagement";
        options.LoginPath = "/User/Login";
        options.AccessDeniedPath = "/Manager/Manager/AccessDenied";

    });

Logger log = new LoggerConfiguration().WriteTo.Console().WriteTo.File("logs/log.txt").CreateLogger();

builder.Host.UseSerilog(log);

var app = builder.Build();
//app.PrepareDatabase().GetAwaiter().GetResult();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<GlobalExceptionsLogsMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Manager}/{action=Index}/{id?}"
    );
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=User}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
