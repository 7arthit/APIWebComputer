using ExWebComputer.Model;

namespace ExWebComputer.Repositories
{
    public interface IProductRepositories
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);

        Product Create(Product product);

        Product? Update(Product product);

        Product? Delete(int id);



    }
}
