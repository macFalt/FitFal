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
    
    public IActionResult Index(DateTime? selectedDate)
    {
        if (!selectedDate.HasValue || selectedDate == DateTime.MinValue)
        {
            selectedDate = DateTime.Today;
        }
        var model = _workoutService.GetWorkout(selectedDate.Value);
        model.StartWorkout = selectedDate.Value;
        return View(model);
    }
    
    [HttpGet]
    public IActionResult AddWorkoutToDay(DateTime workoutData)
    {
        var model = new NewWorkoutVm();
        // model.StartWorkout = DateTime.Today;
        model.StartWorkout = workoutData;
        return View(model);
    }
    
    [HttpPost]
    public IActionResult AddWorkoutToDay(NewWorkoutVm model)
    {
        var id = _workoutService.AddWorkout(model);
        DateTime workoutDate = model.StartWorkout;

        return RedirectToAction("Index", new { selectedDate = workoutDate });
    }
    
    [HttpGet]
    public IActionResult AddExerciseToWorkout(int workoutId)
    {
        var exercises = _exerciseService.GetAllExercisesForList(10,1,"");
        var model = new NewWorkoutExerciseVm()
        {
            Exercises = exercises.ExerciseForListVms,
            WorkoutId = workoutId
        };

        
        return View(model);
    }
    
    [HttpPost]
    public IActionResult  AddExerciseToWorkout(NewWorkoutExerciseVm model)
    {
        var id = _workoutService.AddExerciseToWorkout(model);
        return RedirectToAction("Index");

    }

    public IActionResult DeleteWorkout(int workoutid,DateTime workoutData)
    {
        _workoutService.DeleteWorkout(workoutid);
        return RedirectToAction("Index", new { selectedDate = workoutData });
    }
    public IActionResult Delete(int id)
    {
        _workoutService.DeleteProduct(id);
        return RedirectToAction("Index");    
    }

    public IActionResult Details(int id)
    {
        var model = _exerciseService.GetExerciseDetailByWorkoutExercise(id);
        return View(model);   
    }
    
    [HttpGet]
    public IActionResult EditExercise2(int workoutId)
    {
        var exercise = _workoutService.GetWorkoutExerciseById(workoutId);
        return View(exercise);
    }

    [HttpPost]
    public IActionResult EditExercise2(NewWorkoutExerciseVm model)
    {
        _workoutService.UpdateExercise(model);
        return RedirectToAction("Index");
    }
}
