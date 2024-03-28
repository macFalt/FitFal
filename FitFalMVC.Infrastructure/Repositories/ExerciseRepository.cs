using FitFalMVC.Domain.Interfaces;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Infrastructure.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly Context _context;

    public ExerciseRepository(Context context)
    {
        _context = context;
    }
    public IQueryable<Exercise> GetAllExercises()
    {
        return _context.Exercises.AsQueryable();
    }

    public Exercise GetDetail(int id)
    {
        return _context.Exercises.FirstOrDefault(e => e.Id == id);
    }
    
    public Exercise GetDetailByWorkoutExercise(int id)
    {
        var workoutExercise = _context.WorkoutExercises.FirstOrDefault(we => we.Id == id);

        return _context.Exercises.FirstOrDefault(e => e.Id == workoutExercise.ExerciseId);
    }
}