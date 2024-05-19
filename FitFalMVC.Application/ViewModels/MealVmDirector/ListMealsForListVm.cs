using AutoMapper;
using FitFalMVC.Application.Mapping;

namespace FitFalMVC.Application.ViewModels.MealVmDirector;

public class ListMealsForListVm 
{
    public List<MealForListVm> Meals { get; set; }
    public List<MealDetailVm> Products { get; set; }
}