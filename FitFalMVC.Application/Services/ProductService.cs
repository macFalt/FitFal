using AutoMapper;
using AutoMapper.QueryableExtensions;
using FitFalMVC.Application.Interfaces;
using FitFalMVC.Application.ViewModels.ProductVmDirector;
using FitFalMVC.Domain.Interfaces;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.Services;

public class ProductService : IProductService
{

    private readonly IProductRepository _productRepo;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepo,IMapper mapper)
    {
        _productRepo = productRepo;
        _mapper = mapper;
    }

    public NutritionalValuesVM GetDetails(int nvId)
    {
        var nutritionalValue = _productRepo.GetDetails(nvId);
        var nutritionalValueVm = _mapper.Map<NutritionalValuesVM>(nutritionalValue);
        return nutritionalValueVm;
    }

    public NewProductVm GetproductForEdit(int id)
    {
        var product = _productRepo.GetProductById(id);
        var productVm = _mapper.Map<NewProductVm>(product);
        return productVm;
    }

    public void UpdateProduct(NewProductVm model)
    {
        var customer = _mapper.Map<Product>(model);
        _productRepo.UpdateProduct(customer);
    }

    public void DeleteProduct(int id)
    {
        _productRepo.DeleteProduct(id);
    }


    public ListProductForListVM GetAllProductForList(int pageSize,int pageNO,string searchString)
    {
        
        var products = _productRepo.GetAllProduct().Where(p=>p.Name.StartsWith(searchString))
            .ProjectTo<FitFalMVC.Application.ViewModels.ProductVmDirector.ProductForListVM>(_mapper.ConfigurationProvider).ToList();
        var productToShow = products.Skip(pageSize * (pageNO - 1)).Take(pageSize).ToList();
        var productsList = new ListProductForListVM()
        {
            PageSize = pageSize,
            CurrentPage = pageNO,
            SearchString = searchString,
            Products = productToShow,
            Count = products.Count
        };

        return productsList;
        

/*
        var products = _productRepo.GetAllProduct();
        ListProductForListVM result = new ListProductForListVM();
        result.Products = new List<ProductForListVM>();
        foreach (var product in products)
        {
            var proVm = new ProductForListVM()
            {
                Id = product.Id,
                Name = product.Name
            };
            result.Products.Add(proVm);
        }

        result.Count = result.Products.Count;
        return result;
  */      
    }

    public int AddProduct(NewProductVm product)
    {
        var prod = _mapper.Map<Product>(product);
        var id = _productRepo.AddProduct(prod);
        return id;
        
    }

    public ProductDetailVm GetProductById(int customerId)
    {
        throw new NotImplementedException();
    }
}