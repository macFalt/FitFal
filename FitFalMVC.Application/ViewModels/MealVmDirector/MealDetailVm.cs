using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Application.ViewModels.ProductVmDirector;
using System.Collections.Generic;
using System.Linq;


namespace FitFalMVC.Application.ViewModels.MealVmDirector;

public class MealDetailVm :IMapFrom<FitFalMVC.Domain.Model.Meal>
{
    public string Name { get; set; }
        
    public int Calories { get; set; }
    
    public float Protein { get; set; }
    
    public float Fat { get; set; }
    
    public float Carbohydrates { get; set; }
    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<FitFalMVC.Domain.Model.Meal, FitFalMVC.Application.ViewModels.MealVmDirector.MealDetailVm>()
            .ForMember(a => a.Name,
                opt => opt.MapFrom(
                    b => b.Products.Select(mp=>new MealProductsVm
                    {
                        Name=mp.Name
                    })));
    }  
    
}