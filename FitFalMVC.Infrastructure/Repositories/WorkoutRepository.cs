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
            .Include(e => e.Exercise) // Dołącz ćwiczenie związane z danym WorkoutExercise
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
        return workout;
    }

    public void DeleteProduct(int id)
    {
        var exercise = _context.WorkoutExercises.FirstOrDefault(d => d.Id == id);
        if (exercise != null)
        {
            _context.WorkoutExercises.Remove(exercise);
            _context.SaveChanges();
        }
    }

    public void UpdateExercise(int workoutId, int exerciseId, int sets, int reps,float weight)
    {
        var exercise = _context.WorkoutExercises.FirstOrDefault(d => d.WorkoutId == workoutId);
        // _context.Attach(exercise);
        // _context.Entry(exercise).Property("Sets").IsModified = true;
        // _context.Entry(exercise).Property("Reps").IsModified = true;
        // _context.SaveChanges();
        
        
        
    
        if (exercise != null)
        {
            // Aktualizuj ilość serii i powtórzeń
            exercise.Sets = sets;
            exercise.Reps = reps;
            exercise.Weight = weight;

            // Oznacz te pola jako zmodyfikowane, jeśli wymaga to podjęcia dodatkowych kroków w kontekście Entity Framework
            _context.Entry(exercise).Property(e => e.Sets).IsModified = true;
            _context.Entry(exercise).Property(e => e.Reps).IsModified = true;
            _context.Entry(exercise).Property(e => e.Weight).IsModified = true;

            // Zapisz zmiany do bazy danych
            _context.SaveChanges();
        }
    }
}


