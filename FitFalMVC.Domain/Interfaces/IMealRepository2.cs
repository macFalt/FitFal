using FitFalMVC.Domain.Model;

namespace FitFalMVC.Domain.Interfaces;

public interface IMealRepository2
{
    List<Meal> GetMeal(DateTime selectedDate,string userId);
 
    List<Product> GetProduct(int mealId, string userId);
    int GetGrammageForProduct(int productId, int mealId);

    int AddMeal(Meal meal);
    void DeleteMeal(int mealid);
    
    int AddProduct(MealProduct prod);
    DateTime GetMealData(int modelMealId);
    void UpdateProduct(MealProduct mealproduct);
    void DeleteProduct(int id);
    MealProduct GetMealProductById(int id);
    bool DoesProductExistInMeal(int modelMealId, int modelProductId);
}

