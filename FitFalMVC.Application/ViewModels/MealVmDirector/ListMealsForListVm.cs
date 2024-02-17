using AutoMapper;

namespace FitFalMVC.Application.ViewModels.MealVmDirector;

public class ListMealsForListVm
{
    public List<MealForListVm> Meals { get; set; }
    public List<MealDetailVm> Products { get; set; }

    public List<DayOfEatingForListVm> DayOfEatingForListVms { get; set; }



}