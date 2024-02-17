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

    [HttpGet]
    public IActionResult Index() //bool showProducts = false
    {
        var model = _mealService.GetAllMealsForList();
        //ViewBag.ShowProducts = showProducts;



        return View(model);
    }
    

    [HttpGet]
    public IActionResult AddProductToMeal(int productId, int mealId)
    {
        try
        {
            var result = _mealService.AddProductMeal(productId, mealId);
            return Ok($"Product added to Meal with ID {result}");
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult ListOfProduct(int mealId)
    {
        //ViewBag.MealId = mealId;
        TempData["MealId"] = mealId;
        var model = _productService.GetAllProductForList(2, 1, "");
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
    
    [HttpPost]
    public IActionResult AddDayOfEating(DateTime selectedDate,DayOfEatingForListVm dayOfEatingForListVm)
    {
        var allMeals = _mealService.GetAllMealsForList().Meals;
        dayOfEatingForListVm.Data = selectedDate.Date;
        dayOfEatingForListVm.Meals = allMeals;
        

        _mealService.AddNewDay(dayOfEatingForListVm);
        
        return RedirectToAction("Index");    
    }


}
