using FitFalMVC.Domain.Model;

namespace FitFalMVC.Domain.Interfaces;

public interface IWorkoutRepository
{
    // bool WorkoutExistForDate(DateTime selectedDate);
    Workout GetWorkout(DateTime selectedDate, string userId);
    List<WorkoutExercise> GetExercises(int workoutId, string userId);
    // void AddExerciseTo(WorkoutExercise workout);
    // Workout GetWorkoutById(int workoutId);
    void DeleteProduct(int id);
    
    int AddWorkout(Workout product);
    void DeleteWorkout(int workoutid);
    int AddExercise(WorkoutExercise exer);
    WorkoutExercise GetWorkoutExerciseById(int id);
    void UpdateProduct(WorkoutExercise workoutexercise);
}