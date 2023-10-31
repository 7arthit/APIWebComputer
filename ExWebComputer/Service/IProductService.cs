using ExWebComputer.Model;

namespace ExWebComputer.Service
{
    public interface IProductService
    {
        List<Product> GetProducts(string? search, int? typeId, int? page, int? per_page);

        Product? GetProduct(int productId);

        Product CreatProduct(Product product);

        Product? UpdateProduct(Product product);

        Product? DeleteProduct(int productId);
    }
}
