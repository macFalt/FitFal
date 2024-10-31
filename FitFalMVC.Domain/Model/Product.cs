﻿using System;
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
        
        public float Calories { get; set; }

        public float Protein { get; set; }

        public float Fat { get; set; }

        public float Carbohydrates { get; set; }
        
        public string UserId { get; set; }
    
        public ApplicationUser ApplicationUser { get; set; }
        
        public ICollection<MealProduct> MealProducts { get; set; }
        


    }
}
