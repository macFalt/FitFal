using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.ViewModels.Meal2VmDirector;

public class MealForListVm : IMapFrom<Meal>
{
    public int Id { get; set; }
    public string Name  { get; set; }
    
    public List<ProductForListVm> Products { get; set; } 

    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<Meal, MealForListVm>().ReverseMap();
    }
}