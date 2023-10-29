using ExWebComputer.Model;

namespace ExWebComputer.Service
{
    public interface IProductService
    {
        List<Product> GetProducts();

        Product? GetProduct(int productId);
        Product CreatProduct(Product product);
        Product? UpdateProduct(Product product);
        Product? DeleteProduct(int productId);
    }
}
