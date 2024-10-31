using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.ViewModels.WorkoutVmDirector;

public class WorkoutDetailVm : IMapFrom<Workout>
{
    public int Id { get; set; }
    
    public string Description  { get; set; }
    
    public DateTime StartWorkout { get; set; }
    
    
    public List<ExerciseForListVm> Exercises { get; set; } 

    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<Workout, WorkoutDetailVm>().ReverseMap();

        profile.CreateMap<Exercise, ExerciseForListVm>();
        profile.CreateMap<WorkoutExercise, WorkoutDetailVm>().ReverseMap();
    }
    
}