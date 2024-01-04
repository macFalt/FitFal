using FitFalMVC.Domain.Model;
using FitFalMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFalMVC.Infrastructure.Repositories
{
    public class MealRepository : IMealRepository
    {
        private readonly Context _context;

        public MealRepository(Context context)
        {
            _context = context;
        }

        public void DeleteMeal(int mealId)
        {
            var meal = _context.Meals.Find(mealId);
            if (meal!=null)
            {
                _context.Meals.Remove(meal);
                _context.SaveChanges();
            }
        }


        public int AddMeal(Meal meal)
        {
            _context.Meals.Add(meal);
            _context.SaveChanges();
            return meal.Id;

        }

        public Meal GetMealById(int mealId)
        {
            var meal= _context.Meals.FirstOrDefault(i=>i.Id==mealId);
            return meal;
        }

        public List<Meal> GetAllMeal
        {
            var meals=_context.Meals.ToList();
            return meals;
        }

        public void UpdateMeal(Meal updatingMeal)
        {
            var existingMeal=_context.Meals.FirstOrDefault(i=>i.Id==updatingMeal.Id);
            if (existingMeal=! null)
            {
                existingMeal.Name=updatingMeal.Name;
            }
        }

    }
}
