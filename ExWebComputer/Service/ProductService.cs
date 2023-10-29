using ExWebComputer.Data;
using ExWebComputer.Model;
using ExWebComputer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExWebComputer.Service
{
    public class ProductService : IProductService
    {

        private readonly IProductRepositories _productRepo;

        public ProductService(IProductRepositories productRepo)
        {
            _productRepo = productRepo;
        }

        public List<Product> GetProducts()
        {
            return _productRepo.GetAll().ToList();
        }

        public Product? GetProduct(int productId)
        {
            return _productRepo.GetById(productId);
        }


        public Product CreatProduct(Product product)
        {
            return _productRepo.Create(product);
        }

        public Product? UpdateProduct(Product product)
        {
            return _productRepo.Update(product);
        }

        public Product? DeleteProduct(int productId)
        {
            return _productRepo.Delete(productId);
        }
    }
}
