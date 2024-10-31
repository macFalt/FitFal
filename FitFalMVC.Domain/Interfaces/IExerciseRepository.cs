using FitFalMVC.Domain.Model;

namespace FitFalMVC.Domain.Interfaces;

public interface IExerciseRepository
{
    IQueryable<Exercise> GetAllExercises();
    Exercise GetDetail(int id);
    Exercise GetDetailByWorkoutExercise(int id);
}