using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.ViewModels.MealVmDirector;

public class DayOfEatingForListVm : IMapFrom<FitFalMVC.Domain.Model.DayOfEating>
{
    public int Id { get; set; }
    
    public DateTime Data { get; set; }
    
    public List<MealForListVm> Meals { get; set; }

    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<DayOfEating,DayOfEatingForListVm>();

        profile.CreateMap<MealForListVm, Meal>().ReverseMap();
    }
}