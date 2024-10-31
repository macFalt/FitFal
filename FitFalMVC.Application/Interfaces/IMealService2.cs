using FitFalMVC.Application.ViewModels.Meal2VmDirector;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.Interfaces;

public interface IMealService2
{
    MealDetailsVm GetMeal(string userId, DateTime selectedDate);
    int AddMeal(NewMealVm model);
    void DeleteMeal(int mealid);
    int AddProductToMeal(NewProductInMealVm model);
    DateTime GetMealDate(int modelMealId);
    NewProductInMealVm GetMealProductById(int mealId);
    void UpdateProduct(NewProductInMealVm model);
    void DeleteProduct(int id);
    bool DoesProductExistInMeal(int modelMealId, int modelProductId);
}