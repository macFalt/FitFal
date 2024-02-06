using AutoMapper;
using FitFalMVC.Application.Mapping;

namespace FitFalMVC.Application.ViewModels.ProductVmDirector;

public class ProductDetailVm : IMapFrom<FitFalMVC.Domain.Model.Product>
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public int Calories { get; set; }

    public float Protein { get; set; }

    public float Fat { get; set; }

    public float Carbohydrates { get; set; }

    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<FitFalMVC.Domain.Model.Product, FitFalMVC.Application.ViewModels.ProductVmDirector.ProductDetailVm>(); //w nawiasach pierwsze to zrodlo drugie to destynacja. Jesli mamy te same nazwy to nie trzeba pisac .ForMember
        
    }
    
}