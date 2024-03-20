using FitFalMVC.Domain.Interfaces;
using FitFalMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace FitFalMVC.Infrastructure.Repositories;

public class WorkoutRepository : IWorkoutRepository
{

    private readonly Context _context;

    public WorkoutRepository(Context context)
    {
        _context = context;
    }

    public bool WorkoutExistForDate(DateTime selectedDate)
    {
        return _context.Workouts.Any(m => m.StartWorkout.Date == selectedDate.Date);
    }

    public void AddWorkout(Workout workout)
    {
        _context.Workouts.Add(workout);
        _context.SaveChanges();

    }

    public Workout GetWorkout(DateTime selectedDate)
    {
        var workout = _context.Workouts.FirstOrDefault(i => i.StartWorkout == selectedDate);
        return workout;
    }


    public List<WorkoutExercise> GetExercises(int workoutId)
    {
        return _context.WorkoutExercises
            .Where(e => e.WorkoutId == workoutId)
            .ToList();
    }

    public void AddExerciseTo(WorkoutExercise workout)
    {
        _context.WorkoutExercises.Add(workout);
        
        _context.SaveChanges();
    }

        

public Workout GetWorkoutById(int workoutId)
    {
        var workout = _context.Workouts.FirstOrDefault(i => i.Id == workoutId);
        return workout;    }
}
