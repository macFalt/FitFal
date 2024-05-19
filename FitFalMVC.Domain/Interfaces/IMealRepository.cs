using FitFalMVC.Domain.Model;

namespace FitFalMVC.Domain.Interfaces;

public interface IMealRepository
{
    IQueryable<Meal> GetAllMeals(DateTime selectedData);


    int AddProductTo(int productId, int mealId,int quantity);

    int GetGrammageForProduct(int productId);
    

    void AddMeals(List<Meal> meals);

    // Meal GetMealById(int mealId);

    bool MealsExistForDate(DateTime selectedDate);

    IQueryable<Meal> GetAllMealsById(int mealId);
    void DeleteProduct(int id);
    void AddProd(MealProduct product);
}

