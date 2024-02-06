using AutoMapper;
using FitFalMVC.Application.Mapping;

namespace FitFalMVC.Application.ViewModels.MealVmDirector;

public class NewProductInMealVm : IMapFrom<FitFalMVC.Domain.Model.Product>
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<FitFalMVC.Application.ViewModels.MealVmDirector.NewProductInMealVm,FitFalMVC.Domain.Model.Product>().ReverseMap();
    }
}