using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Domain.Model;
namespace FitFalMVC.Application.ViewModels.ProductVmDirector;

public class NutritionalValuesVM : IMapFrom<FitFalMVC.Domain.Model.NutritionalValues>
{
    public int Id { get; set; }
    
    public int Calories { get; set; }

    public float Protein { get; set; }

    public float Fat { get; set; }

    public float Carbohydrates { get; set; }
    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<FitFalMVC.Domain.Model.NutritionalValues, FitFalMVC.Application.ViewModels.ProductVmDirector.NutritionalValuesVM>(); //w nawiasach pierwsze to zrodlo drugie to destynacja. Jesli mamy te same nazwy to nie trzeba pisac .ForMember
        /*
        .ForMember(d => d.Id,
            opt => opt.MapFrom(
                s => s.Id))
        .ForMember(a => a.Name,
            opt => opt.MapFrom(
                b => b.Name));
*/
    }
}