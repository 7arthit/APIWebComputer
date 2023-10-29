using ExWebComputer.Data;
using ExWebComputer.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ExWebComputer.Repositories
{
    public class ProductRepositories : IProductRepositories
    {

        private readonly AppDbcontext _context;

        public ProductRepositories (AppDbcontext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product? GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }


        public Product Create(Product product)
        {
            EntityEntry<Product> result = _context.Products.Add(product);
            _context.SaveChanges();
            return result.Entity;
        }

        public Product? Update(Product product)
        {
            Product? result = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (result != null)
            {
                result.Id = product.Id;
                result.Name = product.Name;
                result.Description = product.Description;
                result.UnitPrice = product.UnitPrice;
                result.Stock = product.Stock;
                result.Image = product.Image;
                result.ProductTypeId = result.ProductTypeId;
                _context.SaveChanges();
            }
            return null;
        }
        

        public Product? Delete(int id)
        {
            Product? result = _context.Products.FirstOrDefault(p => p.Id == id);
            if (result != null)
            {
                _context.Remove(result);
                _context.SaveChanges();
            }
            return null;
        }
    }
}
