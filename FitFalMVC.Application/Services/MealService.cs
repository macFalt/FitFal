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
   // private IMealService _mealServiceImplementation;

    public MealService(IMealRepository mealRepo,IMapper mapper)
    {
        _mealRepo = mealRepo;
        _mapper = mapper;
    }
    
    // public int AddProductMeal(int productId, int mealId,int quantity)
    // {
    //     return _mealRepo.AddProductTo(productId, mealId, quantity);
    // }
     
    public ListMealsForListVm GetAllMealsForList(DateTime selectedData)
    {
        var mealsFromDb = _mealRepo.GetAllMeals(selectedData)
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
            if (meal.Products != null)
            {
                foreach (var product in meal.Products)
                {
                    var grammage = _mealRepo.GetGrammageForProduct(product.Id);
                    var productVm = _mapper.Map<MealDetailVm>(product);
                    productVm.Grammage = grammage;
                    combinedVm.Products.Add(productVm);
                }
            }
        }
        return combinedVm;
    }
    
    public ListMealsForListVm GetMealById(int mealId)
    {
        var mealsFromDb = _mealRepo.GetAllMealsById(mealId)
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
            if (meal.Products != null)
            {
                foreach (var product in meal.Products)
                {
                    var grammage = _mealRepo.GetGrammageForProduct(product.Id);

                    var productVm = _mapper.Map<MealDetailVm>(product);
                    productVm.Grammage = grammage;

                    combinedVm.Products.Add(productVm);
                }
            }
        }
        return combinedVm;
    }

    

    public void AddMealsToDay(DateTime selectedData)
    {
        bool mealsExist = _mealRepo.MealsExistForDate(selectedData);
        if (!mealsExist)
        {
            List<MealForListVm> mealsOfDay = new List<MealForListVm>();
            string[] mealNames = { "Śniadanie", "II śniadanie", "Obiad", "Przekąska", "Kolacja" };
            foreach (var mealName in mealNames)
            {
                MealForListVm meal = new MealForListVm
                {
                    Name = mealName,
                    Data = selectedData,
                    Products = new List<MealDetailVm>()
                };
                mealsOfDay.Add(meal);
            }
            var mappedMeals = _mapper.Map<List<Meal>>(mealsOfDay);
            _mealRepo.AddMeals(mappedMeals);
        }
    }

    public void DeleteProduct(int id)
    {
        _mealRepo.DeleteProduct(id);
    }

    public int AddProductMeal(NewProductInMeal2Vm productId)
    {
        // var prod = _mapper.Map<MealProduct>(productId);
        // var id = _mealRepo.AddProd(prod);
        // return id;
        return 0;
    }
}
    
    

