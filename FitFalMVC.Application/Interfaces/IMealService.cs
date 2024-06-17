using FitFalMVC.Application.ViewModels.MealVmDirector;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.Interfaces;

public interface IMealService
{

     ListMealsForListVm GetMealById(int mealId);
     
     ListMealsForListVm GetAllMealsForList(DateTime selectedData);
     
     void AddMealsToDay(DateTime selectedData);
     void DeleteProduct(int id);

     int AddProductMeal(NewProductInMeal2Vm productId);
}