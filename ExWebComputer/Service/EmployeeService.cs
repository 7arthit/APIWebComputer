using ExWebComputer.Model;
using ExWebComputer.Repositories;
using System;

namespace ExWebComputer.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepositories _employeeRepo;

        public EmployeeService(IEmployeeRepositories employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        //---------- ค้นหา พนักงาน ----------//

        public List<Employee> GetEmployees(string? search, int? page, int? per_page)
        {
            return _employeeRepo.GetAll(search, page, per_page).ToList();
        }

        //---------- ค้นหา พนักงาน ด้วย id ----------//

        public Employee? GetEmployee(int employeeId)
        {
            return _employeeRepo.GetById(employeeId);
        }

        //---------- เพิ่ม พนักงาน ----------//

        public Employee CreatEmployee(Employee employee)
        {
            return _employeeRepo.Create(employee);
        }

        //---------- แก้ไข พนักงาน ----------//

        public Employee? UpdateEmployee(Employee employee)
        {
            return _employeeRepo.Update(employee);
        }

        //---------- ลบ พนักงาน ----------//

        public Employee? DeleteEmployee(int employeeId)
        {
            return _employeeRepo.Delete(employeeId);
        }
    }
}
