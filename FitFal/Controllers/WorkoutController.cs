using FitFalMVC.Application.Interfaces;
using FitFalMVC.Application.ViewModels.ExerciseVmDirector;
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
        var model = _exerciseService.GetAllExercisesForList2();
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
    
 
    
    
    [HttpGet]
    public IActionResult  AddExerciseToWorkout(int workoutId, int exerciseId, int sets, int reps,float weight)
    {
        _workoutService.AddExerciseToWorkout(workoutId, exerciseId,sets,reps,weight);
        var model = _workoutService.GetWorkoutById(workoutId);
        var xxx = model.StartWorkout;
        var model2 = _workoutService.GetWorkout(xxx);
        return View("Index", model2);

    }

    public IActionResult Delete(int id)
    {
        _workoutService.DeleteProduct(id);
        return RedirectToAction("Index");    }

    public IActionResult Details(int id)
    {
        var model = _exerciseService.GetExerciseDetailByWorkoutExercise(id);
        return View(model);   
    }


    public IActionResult EditExercise(int exerciseId, int workoutid)
    {
        TempData["WorkoutId"] = workoutid;
        TempData["ExerciseId"] = exerciseId;

        return View();    
    }
    
    [HttpGet]
    public IActionResult EditExerciseToWorkout(int workoutId, int exerciseId, int sets, int reps, float weight)
    {
        _workoutService.EditExerciseToWorkout(workoutId, exerciseId,sets,reps,weight);
        var model = _workoutService.GetWorkoutById(workoutId);
        var xxx = model.StartWorkout;
        var model2 = _workoutService.GetWorkout(xxx);
        return View("Index", model2);    }
}