using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Application.ViewModels.ProductVmDirector;
using System.Collections.Generic;
using System.Linq;
using FitFalMVC.Domain.Model;


namespace FitFalMVC.Application.ViewModels.MealVmDirector;

public class MealDetailVm :IMapFrom<FitFalMVC.Domain.Model.Meal>
{
    public string Name { get; set; }
        
    public int Calories { get; set; }
    
    public float Protein { get; set; }
    
    public float Fat { get; set; }
    
    public float Carbohydrates { get; set; }
    
    public List<MealDetailVm> Products { get; set; }
    public List<MealDetailVm> Meals { get; set; }
    
    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<FitFalMVC.Domain.Model.Meal, FitFalMVC.Application.ViewModels.MealVmDirector.MealDetailVm>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        profile.CreateMap<FitFalMVC.Domain.Model.Product, FitFalMVC.Application.ViewModels.MealVmDirector.MealDetailVm>();
        
        profile.CreateMap<FitFalMVC.Domain.Model.Meal, FitFalMVC.Application.ViewModels.MealVmDirector.MealDetailVm>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        
        // profile.CreateMap<FitFalMVC.Application.ViewModels.MealVmDirector.ListMealsForListVm, FitFalMVC.Application.ViewModels.MealVmDirector.MealDetailVm>()
        //     .ForMember(dest => dest.Meals, opt => opt.MapFrom(src => src.Meals));
 
        
    }

    }
        
    
    
