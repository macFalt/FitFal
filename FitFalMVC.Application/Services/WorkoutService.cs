using AutoMapper;
using FitFalMVC.Application.Interfaces;
using FitFalMVC.Application.ViewModels.MealVmDirector;
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



    public void AddWorkoutToDay(DateTime selectedDate, string workoutype)
    {
        bool workoutExist = _workoutRepo.WorkoutExistForDate(selectedDate);
        if (!workoutExist)
        {
            var workout = new WorkoutDetailVm()
            {
                Description = workoutype,
                StartWorkout = selectedDate,
                Exercises = new List<ExerciseForListVm>()
            };
            var mappedWorkout = _mapper.Map<Workout>(workout);
            _workoutRepo.AddWorkout(mappedWorkout);
        }
    }

    public WorkoutDetailVm GetWorkout(DateTime selectedDate)
    {
        var workout = _workoutRepo.GetWorkout(selectedDate);
        if (workout == null)
        {
            return new WorkoutDetailVm();
        }

        var exercises = _workoutRepo.GetExercises(workout.Id);
        var workoutVm = _mapper.Map<WorkoutDetailVm>(workout);

        if (exercises != null && exercises.Any())
        {
            workoutVm.Exercises = new List<ExerciseForListVm>();
            foreach (var exercise in exercises)
            {
                // var exerciseVm = _mapper.Map<ExerciseForListVm>(exercise.Exercise); // Przypisz ćwiczenie wraz z nazwą
                var exerciseVm = _mapper.Map<ExerciseForListVm>(exercise);
                workoutVm.Exercises.Add(exerciseVm); // Dodaj do listy ćwiczeń w workoutVm
            }
        }

        return workoutVm;
    }



    public WorkoutDetailVm GetWorkoutById(int workoutId)
    {
        var workout = _workoutRepo.GetWorkoutById(workoutId);
        // if (workout == null)
        // {
        //     return new WorkoutDetailVm();
        // }
        //
        // var exercises = _workoutRepo.GetExercises(workout.Id);
        // if (exercises == null)
        // {
        //     var workoutVm2 = _mapper.Map<WorkoutDetailVm>(workout);
        //     return workoutVm2;
        // }
        //
        // var exerciseVms = _mapper.Map<List<ExerciseForListVm>>(exercises);
        var workoutVm = _mapper.Map<WorkoutDetailVm>(workout);
        //workoutVm.Exercises = exerciseVms;

        return workoutVm;
    }

    public void DeleteProduct(int id)
    {
        _workoutRepo.DeleteProduct(id);
    }

    public void EditExerciseToWorkout(int workoutId, int exerciseId, int sets, int reps, float weight )
    {
        _workoutRepo.UpdateExercise(workoutId, exerciseId, sets, reps,weight);
    }


    public void AddExerciseToWorkout(int workoutId, int exerciseId,int sets, int reps,float weight)
    {
        var exercise = _exerciseRepo.GetDetail(exerciseId);
        var workout = _workoutRepo.GetWorkoutById(workoutId);
    
        if (exercise != null && workout != null)
        {
            var workoutVm = new WorkoutDetailVm
            {
                Id = workoutId,
                Description = workout.Description,
                StartWorkout = workout.StartWorkout,
                Sets = sets,
                Reps = reps,
                Weight = weight,
                Exercises = new List<ExerciseForListVm>()
            };

            var exerciseVm = new ExerciseForListVm
            {
                Id = exerciseId,
                Name = exercise.Name,

                
            };


            workoutVm.Exercises.Add(exerciseVm);
            
            var workoutexercise = new WorkoutExercise
            {
                WorkoutId = workoutId,
                ExerciseId = exerciseId,
                Sets = sets,
                Reps = reps,
                Weight = weight
            };
            
            var mappedWorkout = _mapper.Map<WorkoutExercise>(workoutexercise);
            _workoutRepo.AddExerciseTo(mappedWorkout);
        }
    }
    

    


}
