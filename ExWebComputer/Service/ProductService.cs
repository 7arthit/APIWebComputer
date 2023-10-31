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

        //---------- ค้นหา สินค้า ----------//

        public List<Product> GetProducts(string? search, int? typeId, int? page, int? per_page)
        {
            return _productRepo.GetAll(search, typeId, page, per_page).ToList();
        }

        //---------- ค้นหา สินค้า ด้วย id ----------//

        public Product? GetProduct(int productId)
        {
            return _productRepo.GetById(productId);
        }

        //---------- เพิ่ม สินค้า ----------//

        public Product CreatProduct(Product product)
        {
            return _productRepo.Create(product);
        }

        //---------- แก้ไข สินค้า ----------//

        public Product? UpdateProduct(Product product)
        {
            return _productRepo.Update(product);
        }

        //---------- ลบ สินค้า ----------//

        public Product? DeleteProduct(int productId)
        {
            return _productRepo.Delete(productId);
        }
    }
}
