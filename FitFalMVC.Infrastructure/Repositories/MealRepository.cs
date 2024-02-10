using FitFalMVC.Domain.Interfaces;
using FitFalMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace FitFalMVC.Infrastructure.Repositories;

public class MealRepository : IMealRepository
{
    private readonly Context _context;

    public MealRepository(Context context)
    {
        _context = context;
    }
    


    public IQueryable<Meal> GetAllMeals()
    {
        return _context.Meals.AsQueryable();
    }

    
    public int AddProductTo(int productId, int mealId)
    {
        var product = _context.Products.Find(productId);
        var meal = _context.Meals.Find(mealId);

        if (product != null && meal != null)
        {
            if (meal.Products == null)
            {
                meal.Products = new List<Product>(); // Inicjalizacja kolekcji, jeśli jest null
            }

            meal.Products.Add(product);
            _context.SaveChanges();
            return meal.Id;
        }

        return -1;

    }

    public Meal GetDetails(int mealId)
    {
        var meal = _context.Meals.FirstOrDefault(n => n.Id==mealId);
        return meal;    }
}