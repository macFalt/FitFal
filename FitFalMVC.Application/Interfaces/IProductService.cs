using FitFalMVC.Application.ViewModels.ProductVmDirector;

namespace FitFalMVC.Application.Interfaces;

public interface IProductService
{
    ListProductForListVM GetAllProductForList();

    int AddProduct(NewProductVm product);

    ProductDetailVm GetProductById(int customerId);



}