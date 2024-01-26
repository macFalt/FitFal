//
//
//
// edycja zaczac od 6min
//
//
//


using FitFalMVC.Application.Interfaces;
using FitFalMVC.Application.Services;
using FitFalMVC.Application.ViewModels;
using FitFalMVC.Domain.Interfaces;
using FitFalMVC.Domain.Model;
using FitFalMVC.Infrastructure;
using FitFalMVC.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Application.ViewModels.ProductVmDirector;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Context>();


builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();




builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddRazorPages();

builder.Services.AddTransient<IValidator<NewProductVm>, NewProductVm.NewProductValidator>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
