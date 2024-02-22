namespace FitFalMVC.Domain.Model;

public class MealProduct
{
    public int Id { get; set; }
    
    public int MealsId { get; set; }

    public Meal Meal { get; set; }

    public int ProductsId { get; set; }

    public Product Product { get; set; }

    public int Grammage { get; set; }
}