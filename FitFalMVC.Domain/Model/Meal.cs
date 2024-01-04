using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFalMVC.Domain.Model
{
    public class Meal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Id_Meal_Product { get; set; }

        public int Id_DayOfEating { get; set; }

        public DayOfEating DayOfEating { get; set; }


        public ICollection<Meal_Product> Meal_Products { get; set; }

        //public ICollection<DayOfEating> DayOfEatings { get; set; }

        //public  Meal_Product Meal_Product { get; set; }


    }
}
