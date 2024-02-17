using FitFalMVC.Domain.Model;

namespace FitFalMVC.Domain.Interfaces;

public interface IMealRepository
{
     IQueryable<Meal> GetAllMeals();

     int AddProductTo(int productId, int mealId);




     // Meal GetMealById(int mealId);


     int AddProduct(DayOfEating day);
     int AddMealToDay(int dayOfEatingId);
}