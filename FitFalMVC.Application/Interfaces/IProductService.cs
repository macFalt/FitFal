using FitFalMVC.Application.ViewModels.ProductVmDirector;

namespace FitFalMVC.Application.Interfaces;

public interface IProductService
{
    ListProductForListVM GetAllProductForList(int pageSize,int pageNO,string searchString);

    int AddProduct(NewProductVm product);
    
    ProductDetailVm GetDetails(int productId);
    
    NewProductVm GetproductForEdit(int id);
    void UpdateProduct(NewProductVm model);
    void DeleteProduct(int id);
    bool CanUserEditProduct(int productId, string userId, bool isAdmin);

}