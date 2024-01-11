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

        public int NutritionalValueId { get; set; }

        public NutritionalValues NutritionalValues { get; set; }
        
        public ICollection<Meal> Meals { get; set; }
        


    }
}
