using FitFalMVC.Domain.Model;

namespace FitFalMVC.Domain.Interfaces;

public interface IMealRepository
{
    Meal GetDetails(int mealId);


    Meal GetMealById(int id);
     
    void UpdateMeal(Meal meal);
    
    void DeleteProductInMeal(int id);

    int AddProductInMeal(Product product);

}