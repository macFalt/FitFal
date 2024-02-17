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
    
    public int AddProductTo(int productId, int mealId )
    {
        var product = _context.Products.Find(productId);
        var meal = _context.Meals.Find(mealId);



        if (product != null && meal != null)
        {
            if (meal.Products == null)
            {
                meal.Products = new List<Product>();
            }

            meal.Products.Add(product);
            // meal.DayOfEatings = dayofeating;


            _context.SaveChanges();
            return meal.Id;
        }

        return -1;

    }

    public int AddMealToDay( int dayOfEatingId)
     {
         var dayOfEating = _context.DayOfEatings.Include(d => d.Meals).FirstOrDefault(d => d.Id == dayOfEatingId);

         if (dayOfEating == null)
         {
             throw new ArgumentException("Invalid dayOfEatingId.", nameof(dayOfEatingId));
         }
         
         var allMeals = _context.Meals.ToList();

         foreach (var meal in allMeals)
         {
             dayOfEating.Meals.Add(meal);
         }

         _context.SaveChanges();

         return dayOfEating.Id;
         
         
         
    //     var meal = _context.Meals.FirstOrDefault(m => m.Id == mealId);
    //     var dayOfEating = _context.DayOfEatings.FirstOrDefault(d => d.Id == dayOfEatingId);
    //
    //     if (meal == null || dayOfEating == null)
    //     {
    //         throw new ArgumentException("Invalid mealId or dayOfEatingId.");
    //     }
    //
    //
    //     _context.SaveChanges();
    //
    //     return meal.Id;
        
        
        // _context.DayOfEatings.Add(dayOfEatingId);
        // _context.SaveChanges();
        // return dayOfEatingId.Id;
    }

    public int AddProduct(DayOfEating day)
    {
        _context.DayOfEatings.Add(day);
        _context.SaveChanges();
        return day.Id;
    }

}

