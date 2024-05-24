using System.Security.AccessControl;

namespace FitFalMVC.Domain.Model;

public class WorkoutExercise
{
    public int Id { get; set; }

    public Workout Workouts { get; set; }

    public int WorkoutId { get; set; }

    public Exercise Exercise { get; set; }

    public int ExerciseId { get; set; }

    public int Sets { get; set; }

    public int Reps { get; set; }

    public float Weight { get; set; }
    
   public string UserId { get; set; }
   
    public ApplicationUser ApplicationUser { get; set; }
}