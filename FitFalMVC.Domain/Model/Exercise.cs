using System.Security.AccessControl;

namespace FitFalMVC.Domain.Model;

public class Exercise
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Instruction { get; set; }

    public string Tips { get; set; }

    public string InvolvedParties { get; set; }
    
    public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    
}