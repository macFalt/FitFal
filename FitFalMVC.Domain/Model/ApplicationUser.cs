using Microsoft.AspNetCore.Identity;

namespace FitFalMVC.Domain.Model;

public class ApplicationUser: IdentityUser
{

    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int? Age { get; set; }
    public double? Weight { get; set; }
    public double? Height { get; set; }
    
    public ICollection<MealProduct> MealProducts { get; set; }
    
    public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    
    public ICollection<Meal> Meals { get; set; }
}