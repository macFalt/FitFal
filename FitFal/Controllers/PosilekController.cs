using FitFalMVC.Application.Interfaces;
using FitFalMVC.Application.ViewModels.Meal2VmDirector;
using FitFalMVC.Application.ViewModels.ProductVmDirector;
using FitFalMVC.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitFal.Controllers;

public class PosilekController : Controller
{
    private readonly IMealService2 _mealService2;
    private readonly IProductService _productService;
    private readonly UserManager<ApplicationUser> _userManager;


    public PosilekController(UserManager<ApplicationUser> userManager,IMealService2 mealService, IProductService productService)
    {
        _mealService2 = mealService;
        _productService = productService;
        _userManager = userManager;

    }
    

    [Authorize]
    public IActionResult Index(DateTime? selectedDate)
    {
        if (!selectedDate.HasValue || selectedDate == DateTime.MinValue)
        {
            selectedDate = DateTime.Today;
        }
        var userId = _userManager.GetUserId(User);
        var model = _mealService2.GetMeal(userId, selectedDate.Value);
        model.Data = selectedDate.Value;
        return View(model);
    }

    
    [HttpGet]
    public IActionResult AddMealToDay(DateTime mealData)
    {
        var model = new NewMealVm();
        model.Data = mealData;
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddMealToDay(NewMealVm model)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToPage("/Account/Login", new { area = "Identity" }); 
        }
        model.UserId = user.Id;
        
        
        var id = _mealService2.AddMeal(model);
        DateTime mealDate = model.Data;

        return RedirectToAction("Index", new { selectedDate = mealDate });
    }

    public IActionResult DeleteMeal(int mealid,DateTime mealData)
    {
        _mealService2.DeleteMeal(mealid);
        return RedirectToAction("Index", new { selectedDate = mealData });
    }

    [HttpGet]
    public IActionResult AddProductToMeal(int mealId,int productId)
    {
        var product = _productService.GetproductForEdit(productId);
        var model = new NewProductInMealVm()
        {
            MealId  = mealId,
            ProductId = productId,
            Calories = product.Calories,
            Carbohydrates = product.Carbohydrates,
            Fat = product.Fat,
            Protein = product.Protein
        };
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddProductToMeal(NewProductInMealVm model)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToPage("/Account/Login", new { area = "Identity" }); 
        }
        model.UserId = user.Id;
        bool productExists = _mealService2.DoesProductExistInMeal(model.MealId, model.ProductId);
        if (!productExists)
        {
            _mealService2.AddProductToMeal(model);
            var mealDate = _mealService2.GetMealDate(model.MealId);
            return RedirectToAction("Index", new { selectedDate = mealDate });
        }
        else
        {
            TempData["ErrorMessage"] = "Produkt już istnieje w tym posiłku.";
            return RedirectToAction("ProductList", new { mealId = model.MealId });
        }
    }
    
    [HttpGet]
    public IActionResult ProductList(int mealId,int pageSize = 10, int pageNo = 1, string searchString = "")
    {
        // var model = _productService.GetAllProductForList(10,1,"");
        var model = _productService.GetAllProductForList(pageSize, pageNo, searchString);
        ViewBag.MealId = mealId;
        return View(model);
        
    }
    [HttpPost]
    public IActionResult ProductList(int pageSize,int? pageNo,string searchString)
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
    
    public IActionResult Delete(int id,DateTime mealData)
    {
        _mealService2.DeleteProduct(id);
        return RedirectToAction("Index", new { selectedDate = mealData });
    }
    
    
    [HttpGet]
    public IActionResult EditGrammage(int mealId)
    {
        var product = _mealService2.GetMealProductById(mealId);
        return View(product);
    }

    [HttpPost]
    public IActionResult EditGrammage(NewProductInMealVm model)
    {
        var userId = _userManager.GetUserId(User);
        model.UserId = userId;
        _mealService2.UpdateProduct(model);
        var mealDate = _mealService2.GetMealDate(model.MealId);

        return RedirectToAction("Index", new { selectedDate = mealDate });
    }
}

