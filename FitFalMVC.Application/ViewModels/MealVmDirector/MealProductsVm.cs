using AutoMapper;
using FitFalMVC.Application.Mapping;

namespace FitFalMVC.Application.ViewModels.MealVmDirector;

public class MealProductsVm : IMapFrom<FitFalMVC.Domain.Model.Meal>
{
    public string Name { get; set; }
        
    public int Calories { get; set; }

    public float Protein { get; set; }

    public float Fat { get; set; }

    public float Carbohydrates { get; set; }
    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<FitFalMVC.Domain.Model.Meal, FitFalMVC.Application.ViewModels.MealVmDirector.MealProductsVm>(); //w nawiasach pierwsze to zrodlo drugie to destynacja. J
    }
}