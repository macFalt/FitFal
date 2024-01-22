using FitFalMVC.Domain.Model;
using FitFalMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFalMVC.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product!=null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }


        public int AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product.Id;

        }
        
        public Product GetProductById(int productId)
        {
            var product= _context.Products.FirstOrDefault(i=>i.Id==productId);
            return product;
        }

        public IQueryable<Product> GetAllProduct()
        {
            var products=_context.Products.AsQueryable();
            return products;
        }

        public void UpdateProduct(Product updatingProduct)
        {
            var existingProduct=_context.Products.FirstOrDefault(i=>i.Id==updatingProduct.Id);
            if (existingProduct != null)
            {
                existingProduct.Name=updatingProduct.Name;
            }
        }

    }
}
