using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.ViewModels.ProductVmDirector;

public class ProductForListVM : IMapFrom<Product>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<Product, ProductForListVM>(); //w nawiasach pierwsze to zrodlo drugie to destynacja. Jesli mamy te same nazwy to nie trzeba pisac .ForMember
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