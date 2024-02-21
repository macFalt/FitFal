using FitFalMVC.Application.ViewModels.MealVmDirector;
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
    
    public IQueryable<Meal> GetAllMeals(DateTime selectedDate)
    {
        return _context.Meals
            .Where(meal => meal.Data.Date == selectedDate.Date)
            .Include(meal => meal.Products);
        
    }
    
    public IQueryable<Meal> GetAllMealsById(int mealId)
    {
        var targetMealDate = _context.Meals
            .Where(meal => meal.Id == mealId)
            .Select(meal => meal.Data)
            .FirstOrDefault();

        return _context.Meals
            .Where(meal => meal.Data == targetMealDate)
            .Include(meal => meal.Products);
        
    }
    
    
    public int AddProductTo(int productId, int mealId)
    {
        var product = _context.Products.Find(productId);
        var meal = _context.Meals.Include(m => m.Products).FirstOrDefault(m => m.Id == mealId);

        if (product != null)
        {
            if (meal.Products == null)
            {
                meal.Products = new List<Product>();
            }

            if (!meal.Products.Any(p => p.Id == productId))
            {
                meal.Products.Add(product);
                _context.SaveChanges();
                return meal.Id; 
            }
            else
            {
                return -1;
            }
        }
        return -1; 
    }


    public void AddMeals(List<Meal> meals)
    {

            foreach (var mealVm in meals)
            {
                var meal = new Meal
                {
                    Name = mealVm.Name,
                    Data = mealVm.Data,
 
                };

                _context.Meals.Add(meal);
            }

            _context.SaveChanges();
        
        
        
    }
    
    public bool MealsExistForDate(DateTime selectedDate)
    {
        return _context.Meals.Any(m => m.Data.Date == selectedDate.Date);
    }



    




}

