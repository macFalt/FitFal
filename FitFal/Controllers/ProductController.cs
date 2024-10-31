using FitFalMVC.Application.Interfaces;
using FitFalMVC.Application.Services;
using FitFalMVC.Application.ViewModels.ProductVmDirector;
using FitFalMVC.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitFal.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly UserManager<ApplicationUser> _userManager;


    public ProductController(IProductService productService, UserManager<ApplicationUser> userManager)
    {
        _productService = productService;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index(int pageSize = 10, int pageNo = 1, string searchString = "")
    {
        var model = _productService.GetAllProductForList(pageSize, pageNo, searchString);
        var userId = _userManager.GetUserId(User);
        var isAdmin = User.IsInRole("Admin");
        ViewBag.IsAdmin = isAdmin;
        ViewBag.UserId = userId;
        return View(model);
    }

    
    // [HttpGet]
    // public IActionResult Index()
    // {
    //     var model = _productService.GetAllProductForList(10, 1, "");
    //     var userId = _userManager.GetUserId(User);
    //     var isAdmin = User.IsInRole("Admin");
    //     ViewBag.IsAdmin = isAdmin;
    //     ViewBag.UserId = userId;
    //     return View(model);
    // }

    // [HttpPost]
    // public IActionResult Index(int pageSize, int? pageNo, string searchString)
    // {
    //     if (!pageNo.HasValue)
    //     {
    //         pageNo = 1;
    //     }
    //
    //     if (searchString is null)
    //     {
    //         searchString = String.Empty;
    //     }
    //
    //     var model = _productService.GetAllProductForList(pageSize, pageNo.Value, searchString);
    //     var userId = _userManager.GetUserId(User);
    //     var isAdmin = User.IsInRole("Admin");
    //     ViewBag.IsAdmin = isAdmin;
    //     ViewBag.UserId = userId;
    //     return View(model);
    // }


    public IActionResult Details(int id)
    {
        var model = _productService.GetDetails(id);
        return View(model);
    }

    [Authorize]
    [HttpGet]
    public IActionResult AddProduct()
    {
        return View(new NewProductVm());
    }

    [Authorize]
    [HttpPost]
    public IActionResult AddProduct(NewProductVm model)
    {
        var userId = _userManager.GetUserId(User);
        model.UserId = userId;
        var id = _productService.AddProduct(model);
        return RedirectToAction("Index");
    }


    [HttpGet]
    public async Task<IActionResult> EditProduct(int id)
    {

        var product = _productService.GetproductForEdit(id);
        return View(product);
    }


    [HttpPost]
    public IActionResult EditProduct(NewProductVm model)
    {
        var userId = _userManager.GetUserId(User);
        model.UserId = userId;
        _productService.UpdateProduct(model);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        _productService.DeleteProduct(id);
        return RedirectToAction("Index");
    }
}