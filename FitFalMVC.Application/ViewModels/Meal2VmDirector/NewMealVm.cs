using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Application.ViewModels.WorkoutVmDirector;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.ViewModels.Meal2VmDirector;

public class NewMealVm : IMapFrom<Meal>
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public DateTime Data { get; set; }
    
    public string ApplicationUser { get; set; }
    public string UserId { get; set; }

    public List<ProductForListVm> Products { get; set; } 
    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<Meal, NewMealVm>().ReverseMap();

    }

    
}