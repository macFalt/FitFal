namespace FitFalMVC.Application.ViewModels.ExerciseVmDirector;

public partial class ListExerciseForListVm
{
    public List<ExerciseForListVm> ExerciseForListVms { get; set; }
    
    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public string SearchString { get; set; }
    public int Count { get; set; }
}