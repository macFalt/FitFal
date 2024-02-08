using FitFalMVC.Application.ViewModels.MealVmDirector;

namespace FitFalMVC.Application.Interfaces;

public interface IMealService
{
     int AddProductMeal(int productId, int mealId);


     
     ListMealsForListVm GetAllMealsForList();


}