using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.ViewModels.Meal2VmDirector;

public class ProductForListVm : IMapFrom<Product>
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Grammage { get; set; }
    
    public float Calories { get; set; }

    public float Protein { get; set; }

    public float Fat { get; set; }

    public float Carbohydrates { get; set; }

    

    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<Product, ProductForListVm>().ReverseMap();
        profile.CreateMap<MealProduct, ProductForListVm>()
            .ForMember(dest => dest.Grammage, opt => opt.MapFrom(src => src.Grammage))
            .ReverseMap();


    }
}