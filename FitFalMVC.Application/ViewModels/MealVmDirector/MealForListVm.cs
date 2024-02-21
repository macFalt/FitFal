using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.ViewModels.MealVmDirector;

public class MealForListVm : IMapFrom<FitFalMVC.Domain.Model.Meal>
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime Data { get; set; }
    public List<MealDetailVm> Products { get; set; }
    
    public void ConfigureMapping(Profile profile)
    {
         profile.CreateMap<FitFalMVC.Domain.Model.Meal, FitFalMVC.Application.ViewModels.MealVmDirector.MealForListVm>().ReverseMap();

    }

}