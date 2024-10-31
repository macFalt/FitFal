using FitFalMVC.Application.ViewModels.ExerciseVmDirector;

namespace FitFalMVC.Application.Interfaces;

public interface IExerciseService
{
    ListExerciseForListVm GetAllExercisesForList(int pageSize, int pageNO, string searchString);
    ExerciseDetailVm GetExerciseDetail(int id);

    ListExerciseForListVm GetAllExercisesForList2();
    ExerciseDetailVm GetExerciseDetailByWorkoutExercise(int id);
}
