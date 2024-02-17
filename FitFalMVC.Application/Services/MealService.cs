using AutoMapper;
using AutoMapper.QueryableExtensions;
using FitFalMVC.Application.Interfaces;
using FitFalMVC.Application.ViewModels.MealVmDirector;
using FitFalMVC.Domain.Interfaces;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.Services;

public class MealService : IMealService
{
    
    private readonly IMealRepository _mealRepo;
    private readonly IMapper _mapper;
    private IMealService _mealServiceImplementation;

    public MealService(IMealRepository mealRepo,IMapper mapper)
    {
        _mealRepo = mealRepo;
        _mapper = mapper;
    }
    
    public int AddProductMeal(int productId, int mealId)
    {
        return _mealRepo.AddProductTo(productId, mealId);
    }
    
    // public ListProductsInMealVm MapMealToProductsList(int mealId)
    // {
    //     var meal = _mealRepo.GetMealById(mealId); 
    //     var productsListVm = new ListProductsInMealVm
    //     {
    //         Products = _mapper.Map<List<MealDetailVm>>(meal.Products)
    //     };
    //     return productsListVm;
    // }
    
    public ListMealsForListVm GetAllMealsForList()
    {
        var mealsFromDb = _mealRepo.GetAllMeals()
            .ProjectTo<FitFalMVC.Application.ViewModels.MealVmDirector.MealForListVm>(_mapper.ConfigurationProvider)
            .ToList();
        
        var combinedVm = new ListMealsForListVm()
        {
            Meals = new List<MealForListVm>(),
            Products = new List<MealDetailVm>()
        };

        foreach (var meal in mealsFromDb)
        {
            combinedVm.Meals.Add(meal);

            var productsForMeal = meal.Products.Select(product => _mapper.Map<MealDetailVm>(product)).ToList();
            combinedVm.Products.AddRange(productsForMeal);
        }

        return combinedVm;
    }



    public int AddNewDay(DayOfEatingForListVm newDayOfEatingVm )
    {

       var newDayOfEating = _mapper.Map<DayOfEating>(newDayOfEatingVm);

       
       
        var id = _mealRepo.AddProduct(newDayOfEating);
        
        var mealsForDay = newDayOfEatingVm.Meals;
        
        foreach (var mealVm in mealsForDay)
         {
             var meal = _mapper.Map<MealForListVm, Meal>(mealVm);
             
             var mealId = _mealRepo.AddMealToDay(id);
         }

        return id;
    }

    
    }
    
    

