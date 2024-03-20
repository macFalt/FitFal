using FitFalMVC.Application.ViewModels.MealVmDirector;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.Interfaces;

public interface IMealService
{
     int AddProductMeal(int productId, int mealId,int quantity);

     ListMealsForListVm GetMealById(int mealId);
     
     ListMealsForListVm GetAllMealsForList(DateTime selectedData);
     
     void AddMealsToDay(DateTime selectedData);
     void DeleteProduct(int id);

     void GetproductForEdit(int id);
}