using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.ViewModels.ExerciseVmDirector;

public class ExerciseForListVm : IMapFrom<Exercise>
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<FitFalMVC.Domain.Model.Exercise, FitFalMVC.Application.ViewModels.ExerciseVmDirector.ExerciseForListVm>();

    }
}