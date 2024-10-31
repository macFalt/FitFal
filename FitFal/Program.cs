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
using FitFal;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Application.ViewModels.ProductVmDirector;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<Context>(options =>
     options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddErrorDescriber<LocalizedIdentityErrorDescriber>()
    .AddEntityFrameworkStores<Context>();



builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IExerciseRepository, ExerciseRepository>();
builder.Services.AddTransient<IExerciseService, ExerciseService>();
builder.Services.AddTransient<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddTransient<IWorkoutService, WorkoutService>();
builder.Services.AddTransient<IMealRepository2, MealRepository2>();
builder.Services.AddTransient<IMealService2, MealService2>();
builder.Services.AddTransient<IPostRepository, PostRepository>();
builder.Services.AddTransient<IPostService, PostService>();
// builder.Services.AddTransient<IdentityErrorDescriber, LocalizedIdentityErrorDescriber>();

builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddRazorPages();



builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredUniqueChars = 1;
    options.SignIn.RequireConfirmedEmail = false;
    options.User.RequireUniqueEmail = true;
});






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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();