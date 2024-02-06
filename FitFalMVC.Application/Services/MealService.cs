using AutoMapper;
using FitFalMVC.Application.ViewModels.MealVmDirector;
using FitFalMVC.Domain.Interfaces;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.Services;

public class MealService
{
    
    private readonly IMealRepository _mealRepo;
    private readonly IMapper _mapper;

    public MealService(IMealRepository mealRepo,IMapper mapper)
    {
        _mealRepo = mealRepo;
        _mapper = mapper;
    }

    public MealDetailVm GetDetails(int mealId)
    {
        var meal = _mealRepo.GetDetails(mealId);
        var mealVm = _mapper.Map<MealDetailVm>(meal);
        return mealVm;
    }

    public NewProductInMealVm GetMealForEdit(int id)
    {
        var meal = _mealRepo.GetMealById(id);
        var mealVm = _mapper.Map<NewProductInMealVm>(meal);
        return mealVm;
    }

    public void UpdateProduct(NewProductInMealVm model)
    {
        var meal = _mapper.Map<Meal>(model);
        _mealRepo.UpdateMeal(meal);
    }

    public void DeleteProduct(int id)
    {
        _mealRepo.DeleteProductInMeal(id);
    }
    

    public int AddProduct(NewProductInMealVm meal)
    {
        var m = _mapper.Map<Product>(meal);
        var id = _mealRepo.AddProductInMeal(m);
        return id;
        
    }
    
}