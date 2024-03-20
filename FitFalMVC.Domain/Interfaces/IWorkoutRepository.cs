using FitFalMVC.Domain.Model;

namespace FitFalMVC.Domain.Interfaces;

public interface IWorkoutRepository
{
    bool WorkoutExistForDate(DateTime selectedDate);
    void AddWorkout(Workout workout);
    Workout GetWorkout(DateTime selectedDate);
    List<WorkoutExercise> GetExercises(int workoutId);
    void AddExerciseTo(WorkoutExercise workout);
    Workout GetWorkoutById(int workoutId);
}