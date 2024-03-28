using FitFalMVC.Application.Interfaces;
using FitFalMVC.Application.Services;
using FitFalMVC.Application.ViewModels.MealVmDirector;
using FitFalMVC.Application.ViewModels.ProductVmDirector;
using FitFalMVC.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace FitFal.Controllers;

public class MealController : Controller
{
    private readonly IMealService _mealService;
    private readonly IProductService _productService;

    public MealController(IMealService mealService, IProductService productService)
    {
        _mealService = mealService;
        _productService = productService;
    }

    
    public IActionResult Index(DateTime selectedDate)
    {
        if (selectedDate == DateTime.MinValue)
        {
            selectedDate = DateTime.Today;
        }
        var model = _mealService.GetAllMealsForList(selectedDate);
        return View(model);
    }

    
    public IActionResult AddMealsToDay(DateTime selectedDate) 
    {
        if (selectedDate == DateTime.MinValue)
        {
            selectedDate = DateTime.Today;
        }
       _mealService.AddMealsToDay(selectedDate);
       var model = _mealService.GetAllMealsForList(selectedDate);
       return View("Index", model);
    }
    
    [HttpGet]
    public IActionResult AddProductToMeal(int productId, int mealId,int quantity)
    {
            var result = _mealService.AddProductMeal(productId, mealId, quantity);
            var meal = _mealService.GetMealById(mealId);
            return View("Index", meal);
    }

    [HttpGet]
    public IActionResult ListOfProduct(int mealId)
    {
        TempData["MealId"] = mealId;
        var model = _productService.GetAllProductForList(10, 1, "");
        return View(model);

    }

    [HttpPost]
    public IActionResult ListOfProduct(int pageSize, int? pageNo, string searchString, int mealId)
    {
        TempData["MealId"] = mealId;

        if (!pageNo.HasValue)
        {
            pageNo = 1;
        }

        if (searchString is null)
        {
            searchString = String.Empty;
        }

        var model = _productService.GetAllProductForList(pageSize, pageNo.Value, searchString);
        return View(model);

    }


    public IActionResult DeleteProduct(int id)
    {
        _mealService.DeleteProduct(id);
        return RedirectToAction("Index");
        
    }

     // public IActionResult EditProduct(int id)
     // {
     //
     //     return View("Index");
     // }

}
    



