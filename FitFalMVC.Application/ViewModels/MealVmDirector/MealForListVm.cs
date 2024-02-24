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
         profile.CreateMap<FitFalMVC.Domain.Model.Meal, FitFalMVC.Application.ViewModels.MealVmDirector.MealForListVm>()
             .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.MealProducts.Select(mp => mp.Product)));
         profile.CreateMap<MealForListVm, Meal>();

         profile.CreateMap<FitFalMVC.Domain.Model.MealProduct, FitFalMVC.Application.ViewModels.MealVmDirector.MealForListVm>();

    }

}