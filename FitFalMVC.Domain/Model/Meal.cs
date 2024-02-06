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

        public ICollection<Product> Products { get; set; }
        
        public ICollection<DayOfEating> DayOfEatings { get; set; }
        
    }
}
