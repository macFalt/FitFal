using Microsoft.AspNetCore.Identity;

namespace FitFalMVC.Domain.Model;

public class ApplicationUser: IdentityUser
{

    public float Weight { get; set; }
    
    public float Height { get; set; }
    
    public ICollection<MealProduct> MealProducts { get; set; }
    
    public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    
    public ICollection<Meal> Meals { get; set; }
}