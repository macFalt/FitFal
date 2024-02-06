using FitFalMVC.Application.Interfaces;
using FitFalMVC.Application.Services;
using FitFalMVC.Application.ViewModels.ProductVmDirector;
using Microsoft.AspNetCore.Mvc;

namespace FitFal.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var model = _productService.GetAllProductForList(2,1,"");
        return View(model);
        
    }
    [HttpPost]
    public IActionResult Index(int pageSize,int? pageNo,string searchString)
    {
        if (!pageNo.HasValue)
        {
            pageNo = 1;
        }

        if (searchString is null)
        {
            searchString=String.Empty;
        }
        var model = _productService.GetAllProductForList(pageSize,pageNo.Value,searchString);
        return View(model);
        
    }


    public IActionResult Details(int id)
    {
        var model = _productService.GetDetails(id);
        return View(model);
    }

    [HttpGet]
    public IActionResult AddProduct()
    {
        return View(new NewProductVm());
    }

    [HttpPost]
    public IActionResult AddProduct(NewProductVm model)
    {
        var validator = new NewProductVm.NewProductValidator();
        var validationResult = validator.Validate(model);
        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View(model);
        }
        
        var id = _productService.AddProduct(model);
        return RedirectToAction("Index");
    }
    
    
    [HttpGet]
    public IActionResult EditProduct(int id)
    {
        var product = _productService.GetproductForEdit(id);
        return View(product);
    }

    [HttpPost]
    public IActionResult EditProduct(NewProductVm model)
    {
        var validator = new NewProductVm.NewProductValidator();
        var validationResult = validator.Validate(model);
        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View(model);
        }
        
        _productService.UpdateProduct(model);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        _productService.DeleteProduct(id);
        return RedirectToAction("Index");
    }
}