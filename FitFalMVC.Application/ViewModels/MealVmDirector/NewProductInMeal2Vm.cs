namespace FitFalMVC.Application.ViewModels.MealVmDirector
{
    public class NewProductInMeal2Vm
    {
        public int ProductId { get; set; } // Id produktu
        public int MealId { get; set; } // Id posiłku
        public int Quantity { get; set; } // Ilość w gramach

        public string ProductName { get; set; } // Nazwa produktu
        public float Calories { get; set; } // Kalorie
        public float Protein { get; set; } // Białko
        public float Fat { get; set; } // Tłuszcz
        public float Carbohydrates { get; set; } // Węglowodany
    }
}