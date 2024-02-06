using FitFalMVC.Domain.Interfaces;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Infrastructure.Repositories;

public class MealRepository : IMealRepository
{
    private readonly Context _context;

    public MealRepository(Context context)
    {
        _context = context;
    }
    
    public Meal GetDetails(int mealId)
    {
        throw new NotImplementedException();
    }

    public Meal GetMealById(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateMeal(Meal meal)
    {
        throw new NotImplementedException();
    }

    public void DeleteProductInMeal(int productId)
    {
        throw new NotImplementedException();
    }

    public int AddProductInMeal(Product product)
    {
        throw new NotImplementedException();
    }
}