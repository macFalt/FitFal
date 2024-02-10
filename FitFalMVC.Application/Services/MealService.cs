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

    public MealService(IMealRepository mealRepo,IMapper mapper)
    {
        _mealRepo = mealRepo;
        _mapper = mapper;
    }
    

    public int AddProductMeal(int productId, int mealId)
    {
        return _mealRepo.AddProductTo(productId, mealId);
    }
    

    
    public ListMealsForListVm GetAllMealsForList()
    {
        var mealsFromDb = _mealRepo.GetAllMeals()
            .ProjectTo<FitFalMVC.Application.ViewModels.MealVmDirector.MealForListVm>(_mapper.ConfigurationProvider)
            .ToList();

        var mealList = new ListMealsForListVm()
        {
            Meals = mealsFromDb,
        };

        return mealList;
        
        
    }
    

    public ListProductsInMealVm MapMealToProductsList(int mealId)
    {
  

        var meal = _mealRepo.GetMealById(mealId); 
        var productsListVm = new ListProductsInMealVm
        {
            Products = _mapper.Map<List<MealDetailVm>>(meal.Products)
        };

        return productsListVm;
    }
    
    

}