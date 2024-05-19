using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.ViewModels.PosilekVmDirector;

public class PosilekDetailVm : IMapFrom<Meal>
{
    public int Id { get; set; }
    
    public string Name { get; set; }
        
    public float Calories { get; set; }
    
    public float Protein { get; set; }
    
    public float Fat { get; set; }
    
    public float Carbohydrates { get; set; }
    public float Grammage { get; set; }

    public DateTime Date { get; set; }
    public List<ListaProduktow> Products { get; set; }
    public List<ListaPosilkow> Meals { get; set; }
    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<Meal, PosilekDetailVm>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.MealProducts));
            
        profile.CreateMap<Product, PosilekDetailVm>();
        
        profile.CreateMap<MealProduct, PosilekDetailVm>()
            .ForMember(dest => dest.Grammage, opt => opt.MapFrom(src => src.Grammage));
    }
    
}