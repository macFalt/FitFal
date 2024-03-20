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
        if (exercises == null)
        {
            var workoutVm2 = _mapper.Map<WorkoutDetailVm>(workout);
            return workoutVm2;
        }

        var exerciseVms = _mapper.Map<List<ExerciseForListVm>>(exercises);
        var workoutVm = _mapper.Map<WorkoutDetailVm>(workout);
        workoutVm.Exercises = exerciseVms;

        return workoutVm;
    }

    public WorkoutDetailVm GetWorkoutById(int workoutId)
    {
        var workout = _workoutRepo.GetWorkoutById(workoutId);
        if (workout == null)
        {
            return new WorkoutDetailVm();
        }

        var exercises = _workoutRepo.GetExercises(workout.Id);
        if (exercises == null)
        {
            var workoutVm2 = _mapper.Map<WorkoutDetailVm>(workout);
            return workoutVm2;
        }

        var exerciseVms = _mapper.Map<List<ExerciseForListVm>>(exercises);
        var workoutVm = _mapper.Map<WorkoutDetailVm>(workout);
        workoutVm.Exercises = exerciseVms;

        return workoutVm;
    }




    public void AddExerciseToWorkout(int workoutId, int exerciseId)
    {
        var exercise = _exerciseRepo.GetDetail(exerciseId);
        var workout = _workoutRepo.GetWorkoutById(workoutId);
    
        if (exercise != null && workout != null)
        {
            // Tworzymy ViewModel i dodajemy do niego ćwiczenie
            var workoutVm = new WorkoutDetailVm
            {
                WorkoutId = workoutId,
                Description = workout.Description,
                StartWorkout = workout.StartWorkout,
                Sets = 10,
                Reps = 10,
                Exercises = new List<ExerciseForListVm>()
            };

            var exerciseVm = new ExerciseForListVm
            {
                Id = exerciseId,
                Name = exercise.Name
            };

            var workoutexercise = new WorkoutExercise
            {
                WorkoutId = workoutId,
                ExerciseId = exerciseId,
                Sets = 10,
                Reps = 10
            };
            workoutVm.Exercises.Add(exerciseVm);

            
            var mappedWorkout = _mapper.Map<WorkoutExercise>(workoutexercise);
            _workoutRepo.AddExerciseTo(mappedWorkout);
        }
    }
}
