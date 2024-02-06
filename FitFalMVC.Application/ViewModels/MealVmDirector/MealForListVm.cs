using AutoMapper;
using FitFalMVC.Application.Mapping;

namespace FitFalMVC.Application.ViewModels.MealVmDirector;

public class MealForListVm : IMapFrom<FitFalMVC.Domain.Model.Meal>
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<FitFalMVC.Domain.Model.Meal, FitFalMVC.Application.ViewModels.MealVmDirector.MealForListVm>();
    }

}