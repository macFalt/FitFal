using FitFalMVC.Application.ViewModels.WorkoutVmDirector;

namespace FitFalMVC.Application.Interfaces;

public interface IWorkoutService
{
    void AddWorkoutToDay(DateTime selectedDate,string workoutype);
    WorkoutDetailVm GetWorkout(DateTime selectedDate);
    void AddExerciseToWorkout(int workoutId, int exerciseId);
    // int AddExerciseToWorkout(WorkoutDetailVm workoutDetailVm);
    WorkoutDetailVm GetWorkoutById(int workoutId);
}
