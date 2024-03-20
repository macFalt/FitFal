using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.ViewModels.ExerciseVmDirector;

public class ExerciseDetailVm: IMapFrom<Exercise>
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
    
    public string Instruction { get; set; }

    public string Tips { get; set; }

    public string InvolvedParties { get; set; }
    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<FitFalMVC.Domain.Model.Exercise, FitFalMVC.Application.ViewModels.ExerciseVmDirector.ExerciseDetailVm>();

    }
}