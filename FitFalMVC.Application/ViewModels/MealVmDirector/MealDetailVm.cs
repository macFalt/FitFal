using AutoMapper;
using FitFalMVC.Application.Mapping;

namespace FitFalMVC.Application.ViewModels.MealVmDirector;

public class MealDetailVm :IMapFrom<FitFalMVC.Domain.Model.Product>
{
    public string Name { get; set; }
        
    public int Calories { get; set; }

    public float Protein { get; set; }

    public float Fat { get; set; }

    public float Carbohydrates { get; set; }
    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<FitFalMVC.Application.ViewModels.MealVmDirector.MealDetailVm,FitFalMVC.Domain.Model.Product>().ReverseMap();
    }
}