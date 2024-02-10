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
    
    public void ConfigureMapping(Profile profile)
    {
        // profile.CreateMap<FitFalMVC.Domain.Model.Meal, FitFalMVC.Application.ViewModels.MealVmDirector.MealDetailVm>()
        //     .ForMember(a => a.Name,
        //         opt => opt.MapFrom(
        //             b => b.Products.Select(mp=>new MealDetailVm
        //             {
        //                 Name=mp.Name
        //             })));
        
        // profile.CreateMap<Meal, MealDetailVm>();
        
        profile.CreateMap<FitFalMVC.Domain.Model.Meal, FitFalMVC.Application.ViewModels.MealVmDirector.MealDetailVm>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        profile.CreateMap<FitFalMVC.Domain.Model.Product, FitFalMVC.Application.ViewModels.MealVmDirector.MealDetailVm>();
    }
        
    }  
    
