namespace FitFalMVC.Application.ViewModels.PostVmDirector;

public class ListPost
{
    public List<PostForListVm> Posts { get; set; }
    
    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public string SearchString { get; set; }
    
    public int Count { get; set; }

}