

using ExWebComputer.Model;

namespace ExWebComputer.Repositories
{
    public interface IEmployeeRepositories
    {
        IEnumerable<Employee> GetAll(string? search, int? page, int? per_page);

        Employee? GetById(int id);

        Employee Create(Employee employee);

        Employee? Update(Employee employee);

        Employee? Delete(int id);
    }
}
