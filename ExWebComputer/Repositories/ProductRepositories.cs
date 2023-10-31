using ExWebComputer.Data;
using ExWebComputer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace ExWebComputer.Repositories
{
    public class ProductRepositories : IProductRepositories
    {

        private readonly AppDbcontext _context;

        public ProductRepositories (AppDbcontext context)
        {
            _context = context;
        }

        //---------- ค้นหา สินค้า ----------//

        public IEnumerable<Product> GetAll(string? search, int? typeId, int? page, int? per_page)
        {
            int pageNumber = page ?? 1;
            int limit = per_page ?? 10;
            return _context.Products.Include("ProductType")
                .Where(p => search == null || p.Name.Contains(search))
                .Where(p => typeId == null || p.ProductTypeId == typeId).Skip((pageNumber - 1) * limit).Take(limit); 
        }

        //---------- ค้นหา สินค้า ด้วย id ----------//

        public Product? GetById(int id)
        {
            return _context.Products.Include("ProductType").FirstOrDefault(p => p.Id == id);
        }

        //---------- เพิ่ม สินค้า ----------//

        public Product Create(Product product)
        {
            EntityEntry<Product> result = _context.Products.Add(product);
            _context.SaveChanges();
            return result.Entity;
        }

        //---------- แก้ไข สินค้า ----------//

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
            return result;
        }

        //---------- ลบ สินค้า ----------//

        public Product? Delete(int id)
        {
            Product? result = _context.Products.FirstOrDefault(p => p.Id == id);
            if (result != null)
            {
                _context.Remove(result);
                _context.SaveChanges();
            }
            return result;
        }
    }
}
