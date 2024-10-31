using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Application.ViewModels.WorkoutVmDirector;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.ViewModels.Meal2VmDirector;

public class MealDetailsVm : IMapFrom<Meal>
{

     public DateTime Data { get; set; }
    public List<MealForListVm> Meals { get; set; } 

    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<Meal, MealDetailsVm>().ReverseMap();
        profile.CreateMap<Product, ProductForListVm>();
        profile.CreateMap<MealProduct, MealDetailsVm>().ReverseMap();
    }
}