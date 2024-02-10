using FitFalMVC.Application.ViewModels.MealVmDirector;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.Interfaces;

public interface IMealService
{
     int AddProductMeal(int productId, int mealId);


     
     ListMealsForListVm GetAllMealsForList();



    ListProductsInMealVm MapMealToProductsList(int meal);
}