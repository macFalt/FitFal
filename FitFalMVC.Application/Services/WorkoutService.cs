using AutoMapper;
using FitFalMVC.Application.Interfaces;
using FitFalMVC.Application.ViewModels.WorkoutVmDirector;
using FitFalMVC.Domain.Interfaces;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.Services;

public class WorkoutService : IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepo;
    private readonly IExerciseRepository _exerciseRepo;
    private readonly IMapper _mapper;

    public WorkoutService(IWorkoutRepository workoutRepo, IExerciseRepository exerciseRepo, IMapper mapper)
    {
        _workoutRepo = workoutRepo;
        _exerciseRepo = exerciseRepo;
        _mapper = mapper;
    }
    
    public WorkoutDetailVm GetWorkout(string userId, DateTime selectedDate)
    {
        var workout = _workoutRepo.GetWorkout(selectedDate, userId);
        if (workout == null)
        {
            return new WorkoutDetailVm();
        }
    
        var exercises = _workoutRepo.GetExercises(workout.Id, userId);
        var workoutVm = _mapper.Map<WorkoutDetailVm>(workout);
    
        if (exercises != null && exercises.Any())
        {
            workoutVm.Exercises = new List<ExerciseForListVm>();
            foreach (var exercise in exercises)
            {
                var exerciseVm = _mapper.Map<ExerciseForListVm>(exercise);
                workoutVm.Exercises.Add(exerciseVm);
            }
        }
        return workoutVm;
    }

    public int AddExerciseToWorkout(NewWorkoutExerciseVm exercise)
    {
        var exer = _mapper.Map<WorkoutExercise>(exercise);
        var id = _workoutRepo.AddExercise(exer);
        return id;    
    }
    

    public void DeleteProduct(int id)
    {
        _workoutRepo.DeleteProduct(id);
    }

    
    public int AddWorkout(NewWorkoutVm product)
    {
        var prod = _mapper.Map<Workout>(product);
        var id = _workoutRepo.AddWorkout(prod);
        return id;
        
    }

    public void DeleteWorkout(int workoutid)
    {
        _workoutRepo.DeleteWorkout(workoutid);
    }

    public NewWorkoutExerciseVm GetWorkoutExerciseById(int id)
    {
        var exercise = _workoutRepo.GetWorkoutExerciseById(id);
        var exerciseVm = _mapper.Map<NewWorkoutExerciseVm>(exercise);
        return exerciseVm;    
    }
    
    public void UpdateExercise(NewWorkoutExerciseVm model)
    {
        var workoutexercise = _mapper.Map<WorkoutExercise>(model);
        _workoutRepo.UpdateProduct(workoutexercise);
    }


   
}
    

    


