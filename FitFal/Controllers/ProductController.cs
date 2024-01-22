using FitFalMVC.Application.Interfaces;
using FitFalMVC.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitFal.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    
    public IActionResult Index()
    {

        var model = _productService.GetAllProductForList();
        return View(model);
        
    }


}