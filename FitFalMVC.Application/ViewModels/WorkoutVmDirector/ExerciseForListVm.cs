using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.ViewModels.WorkoutVmDirector;

public class ExerciseForListVm : IMapFrom<Exercise>
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public void ConfigureMapping(Profile profile)
    {
        
        profile.CreateMap<Exercise, ExerciseForListVm>();
        profile.CreateMap<WorkoutExercise, ExerciseForListVm>();
    }
}