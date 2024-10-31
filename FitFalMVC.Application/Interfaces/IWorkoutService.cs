using FitFalMVC.Application.ViewModels.WorkoutVmDirector;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.Interfaces;

public interface IWorkoutService
{
    WorkoutDetailVm GetWorkout(string userId, DateTime selectedDate);
    
    void DeleteProduct(int id);
    
    int AddExerciseToWorkout(NewWorkoutExerciseVm exercise);

    int AddWorkout(NewWorkoutVm product);

    void DeleteWorkout(int workoutid);
    NewWorkoutExerciseVm GetWorkoutExerciseById(int id);

    void UpdateExercise(NewWorkoutExerciseVm model);
}
