using System.ComponentModel;
using AutoMapper;
using FitFalMVC.Application.Mapping;
using FluentValidation;

namespace FitFalMVC.Application.ViewModels.ProductVmDirector;

public class NewProductVm : IMapFrom<FitFalMVC.Domain.Model.Product>
{
    public int Id { get; set; }
    [DisplayName("Nazwa")]
    public string Name { get; set; }
    
    public int Calories { get; set; }

    public float Protein { get; set; }

    public float Fat { get; set; }

    public float Carbohydrates { get; set; }

    public string UserId { get; set; }

    public string ApplicationUser { get; set; }
    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<FitFalMVC.Application.ViewModels.ProductVmDirector.NewProductVm,FitFalMVC.Domain.Model.Product>().ReverseMap();
    }


    
    
}