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

    // public bool WorkoutExistForDate(DateTime selectedDate)
    // {
    //     return _context.Workouts.Any(m => m.StartWorkout.Date == selectedDate.Date);
    // }
    
    public Workout GetWorkout(DateTime selectedDate,string userId)
    {
        var workout = _context.Workouts.FirstOrDefault(i => i.StartWorkout == selectedDate && i.UserId == userId);
        return workout;
        
        
    }
    
    public List<WorkoutExercise> GetExercises(int workoutId,string userId)
    {
        return _context.WorkoutExercises
            .Where(e => e.WorkoutId == workoutId)
            .Where(e => e.UserId == userId)
            .Include(e => e.Exercise) 
            .ToList();

    }

    // public void AddExerciseTo(WorkoutExercise workout)
    // {
    //     _context.WorkoutExercises.Add(workout);
    //
    //     _context.SaveChanges();
    // }



    // public Workout GetWorkoutById(int workoutId)
    // {
    //     var workout = _context.Workouts.FirstOrDefault(i => i.Id == workoutId);
    //     return workout;
    // }

    public void DeleteProduct(int id)
    {
        var exercise = _context.WorkoutExercises.FirstOrDefault(d => d.Id == id);
        if (exercise != null)
        {
            _context.WorkoutExercises.Remove(exercise);
            _context.SaveChanges();
        }
    }
    
    
    public int AddWorkout(Workout product)
    {
        product.ApplicationUser = _context.ApplicationUsers.Find(product.UserId);

        _context.Workouts.Add(product);
        _context.SaveChanges();
        return product.Id;

    }
    
    public void DeleteWorkout(int workoutid)
    {
        var workoutDetails = _context.WorkoutExercises.Where(wd => wd.WorkoutId == workoutid).ToList();
        if (workoutDetails.Any())
        {
            _context.WorkoutExercises.RemoveRange(workoutDetails);
        }
        var workout = _context.Workouts.Find(workoutid);
        if (workout != null)
        {
            _context.Workouts.Remove(workout);
        }
        _context.SaveChanges();
    }

    public int AddExercise(WorkoutExercise exer)
    {
        exer.Workouts=_context.Workouts.Include(m => m.WorkoutExercises).FirstOrDefault(m => m.Id == exer.WorkoutId);
        exer.Exercise=_context.Exercises.Find(exer.ExerciseId);
        exer.ApplicationUser = _context.ApplicationUsers.Find(exer.UserId);
        _context.WorkoutExercises.Add(exer);
        _context.SaveChanges();
        return exer.Id;    }

    public WorkoutExercise GetWorkoutExerciseById(int id)
    {
        var workoutexercise= _context.WorkoutExercises.FirstOrDefault(i=>i.WorkoutId==id);
        return workoutexercise;    
    }

    public void UpdateProduct(WorkoutExercise workoutexercise)
    {
        _context.Update(workoutexercise);
        _context.Entry(workoutexercise).Property("Sets").IsModified = true;
        _context.Entry(workoutexercise).Property("Reps").IsModified = true;
        _context.Entry(workoutexercise).Property("Weight").IsModified = true;
        _context.SaveChanges();
        
    }
}


