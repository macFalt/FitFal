using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFalMVC.Domain.Model
{
    public class Meal_Product
    {
        public int Id { get; set; }

        public int Id_Meal { get; set; }

        public int Id_Product { get; set; }

        public float Grammage { get; set; }

        public int Calories { get; set; }
    }
}
