using FitFalMVC.Application.Interfaces;
using FitFalMVC.Application.ViewModels.WorkoutVmDirector;
using Microsoft.AspNetCore.Mvc;

namespace FitFal.Controllers;

public class WorkoutController : Controller
{
    private readonly IWorkoutService _workoutService;
    private readonly IExerciseService _exerciseService;
    
    public WorkoutController(IWorkoutService workoutService, IExerciseService exerciseService)
    {
        _workoutService = workoutService;
        _exerciseService = exerciseService;
    }
    
    
    public IActionResult Index(DateTime selectedDate)
    {
        if (selectedDate == DateTime.MinValue)
        {
            selectedDate = DateTime.Today;
        }
        
        var model = _workoutService.GetWorkout(selectedDate);
        return View(model);    }

    public IActionResult AddExercise(int workoutId)
    {
        TempData["WorkoutId"] = workoutId;
        var model = _exerciseService.GetAllExercisesForList(2, 1, "");
        return View(model);
    }
    
    public IActionResult AddWorkoutToDay(DateTime selectedDate,string description) 
    {
        if (selectedDate == DateTime.MinValue)
        {
            selectedDate = DateTime.Today;
        }
        _workoutService.AddWorkoutToDay(selectedDate,description);
        var model = _workoutService.GetWorkout(selectedDate);
        return View("Index", model);
    }
    
    
    [HttpPost]
    public IActionResult  AddExerciseToWorkout(int workoutId, int exerciseId)
    {
        _workoutService.AddExerciseToWorkout(workoutId, exerciseId);
        var workout = _workoutService.GetWorkoutById(workoutId);
        return View("Index", workout);
    
    }
    
    
    // [HttpPost]
    // public IActionResult  AddExerciseToWorkout(WorkoutDetailVm workoutDetailVm)
    // {
    //     _workoutService.AddExerciseToWorkout(workoutDetailVm);
    //     var workout = _workoutService.GetWorkoutById(workoutDetailVm.Id);
    //     return View("Index", workoutDetailVm);
    //
    // }
}