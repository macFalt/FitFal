using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;

namespace FitFalMVC.Domain.Model;

public class Workout
{
    public int Id { get; set; }

    public string Description  { get; set; }

    public DateTime StartWorkout { get; set; }

    public DateTime EndWorkout { get; set; }
    
    public string UserId { get; set; }
    
    public ApplicationUser ApplicationUser { get; set; }

    public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    
    
}