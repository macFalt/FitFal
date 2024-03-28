using FitFalMVC.Application.ViewModels.WorkoutVmDirector;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.Interfaces;

public interface IWorkoutService
{
    void AddWorkoutToDay(DateTime selectedDate, string workoutype);
    WorkoutDetailVm GetWorkout(DateTime selectedDate);

    void AddExerciseToWorkout(int workoutId, int exerciseId, int sets, int reps, float weight);

    // int AddExerciseToWorkout(WorkoutDetailVm workoutDetailVm);
    WorkoutDetailVm GetWorkoutById(int workoutId);
    void DeleteProduct(int id);


    void EditExerciseToWorkout(int workoutId, int exerciseId, int sets, int reps, float weight);
}
