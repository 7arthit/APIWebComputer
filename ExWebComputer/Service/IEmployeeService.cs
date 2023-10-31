using ExWebComputer.DTOs;
using ExWebComputer.Model;

namespace ExWebComputer.Service
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees(string? search, int? page, int? per_page);

        Employee? GetEmployee(int employeeId);

        object CreatEmployee(Employee employee);

        Employee? UpdateEmployee(Employee employee);

        Employee? DeleteEmployee(int employeeId);

        Employee? Login(LoginDTO logindto);
    }
}
