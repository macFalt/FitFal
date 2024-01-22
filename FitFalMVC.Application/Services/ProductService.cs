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
    
    
    public ListProductForListVM GetAllProductForList()
    {

        var products = _productRepo.GetAllProduct()
            .ProjectTo<ProductForListVM>(_mapper.ConfigurationProvider).ToList();
        var productsList = new ListProductForListVM()
        {
            Products = products,
            Count = products.Count
        };

        return productsList;
        


        /*
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
        throw new NotImplementedException();
    }

    public ProductDetailVm GetProductById(int customerId)
    {
        throw new NotImplementedException();
    }
}