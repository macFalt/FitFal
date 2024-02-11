using FitFalMVC.Domain.Model;

namespace FitFalMVC.Domain.Interfaces;

public interface IMealRepository
{
     IQueryable<Meal> GetAllMeals();

     int AddProductTo(int productId, int mealId);




     // Meal GetMealById(int mealId);

}