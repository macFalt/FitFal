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

    public MealDetailVm GetDetails(int mealid)
    {
        var meal = _mealRepo.GetDetails(mealid);
        var mealVm = _mapper.Map<MealDetailVm>(meal);
        return mealVm;
    }
}