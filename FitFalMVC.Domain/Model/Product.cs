using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFalMVC.Domain.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Id_NutritionalValue { get; set; }

        public NutritionalValues NutritionalValues { get; set; }

        public ICollection<Meal_Product> Meal_Products { get; set; }


        //public int TypeId { get; set; }

        //public virtual Type Type { get; set; }





    }
}
