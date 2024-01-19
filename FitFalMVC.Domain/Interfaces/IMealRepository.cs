using FitFalMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFalMVC.Domain.Interfaces
{
    public interface IMealRepository
    {
        void DeleteMeal(int mealId)
        
         int AddMeal(Meal meal)


         Meal GetMealById(int mealId)


         List<Meal> GetAllMeal
   

         void UpdateMeal(Meal updatingMeal)




    }
}
