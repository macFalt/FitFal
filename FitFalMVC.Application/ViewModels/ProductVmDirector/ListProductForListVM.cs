namespace FitFalMVC.Application.ViewModels.ProductVmDirector;

public class ListProductForListVM
{
    public List<ProductForListVM> Products { get; set; }

    
    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public string SearchString { get; set; }
    public int Count { get; set; }
    
    
}