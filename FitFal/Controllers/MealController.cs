using FitFalMVC.Application.Interfaces;
using FitFalMVC.Application.Services;
using FitFalMVC.Application.ViewModels.ProductVmDirector;
using Microsoft.AspNetCore.Mvc;

namespace FitFal.Controllers;

public class MealController : Controller
{
    private readonly IMealService _mealService;
    
    public MealController(IMealService productService)
    {
        _mealService = productService;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var model = _mealService.GetAllMealsForList();
        return View(model);
        
    }

    
    
    [HttpPost]
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
    


}

