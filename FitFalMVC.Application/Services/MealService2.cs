using AutoMapper;
using AutoMapper.QueryableExtensions;
using FitFalMVC.Application.Interfaces;
using FitFalMVC.Application.ViewModels.Meal2VmDirector;
using FitFalMVC.Domain.Interfaces;
using FitFalMVC.Domain.Model;
using MealForListVm = FitFalMVC.Application.ViewModels.Meal2VmDirector.MealForListVm;

namespace FitFalMVC.Application.Services;

public class MealService2 : IMealService2
{
    
    private readonly IMealRepository2 _mealRepo;
    private readonly IMapper _mapper;

    public MealService2(IMealRepository2 mealRepo,IMapper mapper)
    {
        _mealRepo = mealRepo;
        _mapper = mapper;
    }
    


    public MealDetailsVm GetMeal(string userId,DateTime selectedDate)
    {
        var meals = _mealRepo.GetMeal(selectedDate, userId); 

        var mealVm = new MealDetailsVm();
        mealVm.Meals = new List<MealForListVm>();
        mealVm.Data = selectedDate;

        foreach (var meal in meals)
        {
            var mealForListVm = _mapper.Map<MealForListVm>(meal);
            mealVm.Meals.Add(mealForListVm);

            var products = _mealRepo.GetProduct(meal.Id,userId);

            if (products != null && products.Any())
            {
                mealForListVm.Products = new List<ProductForListVm>();

                foreach (var product in products)
                {
                    var productVm = _mapper.Map<ProductForListVm>(product);
                    productVm.Grammage = _mealRepo.GetGrammageForProduct(product.Id,meal.Id);
                    mealForListVm.Products.Add(productVm);
                }
            }
        }

        return mealVm;
    }
    
    public int AddMeal(NewMealVm model)
    {
        var meal = _mapper.Map<Meal>(model);
        var id = _mealRepo.AddMeal(meal);
        return id;    }

    public void DeleteMeal(int mealid)
    {
        _mealRepo.DeleteMeal(mealid);
    }

    public int AddProductToMeal(NewProductInMealVm model)
    {
        var prod = _mapper.Map<MealProduct>(model);
        var id = _mealRepo.AddProduct(prod);
        return id;        
    }

    public DateTime GetMealDate(int modelMealId)
    {
        var mealData = _mealRepo.GetMealData(modelMealId);
        return mealData;
    }

    public NewProductInMealVm GetMealProductById(int mealId)
    {
        var product = _mealRepo.GetMealProductById(mealId);
        var productVm = _mapper.Map<NewProductInMealVm>(product);
        return productVm;   
    }

    public void UpdateProduct(NewProductInMealVm model)
    {
        var mealproduct = _mapper.Map<MealProduct>(model);
        _mealRepo.UpdateProduct(mealproduct);    
    }

    public void DeleteProduct(int id)
    {
        _mealRepo.DeleteProduct(id);
    }

    public bool DoesProductExistInMeal(int modelMealId, int modelProductId)
    {
        return _mealRepo.DoesProductExistInMeal(modelMealId, modelProductId);
    }
}
    
    



