using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FitFalMVC.Domain.Model
{
    public class DayOfEating
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public int MealId { get; set; }

        public Meal Meal { get; set; }

        public ICollection<Meal> Meals { get; set; }





    }
}
