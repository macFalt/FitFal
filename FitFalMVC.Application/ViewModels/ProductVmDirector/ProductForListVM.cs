using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.ViewModels.ProductVmDirector;

public class ProductForListVM : IMapFrom<FitFalMVC.Domain.Model.Product>
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<FitFalMVC.Domain.Model.Product, FitFalMVC.Application.ViewModels.ProductVmDirector.ProductForListVM>(); //w nawiasach pierwsze to zrodlo drugie to destynacja. J
    }
    
}