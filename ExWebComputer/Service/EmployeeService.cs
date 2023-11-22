using ExWebComputer.DTOs;
using ExWebComputer.Model;
using ExWebComputer.Repositories;
using System;
using System.Net;

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

        public List<Employee> GetEmployees(string? search)
        {
            return _employeeRepo.GetAll(search).ToList();
        }

        //---------- ค้นหา พนักงาน ด้วย id ----------//

        public Employee? GetEmployee(int employeeId)
        {
            return _employeeRepo.GetById(employeeId);
        }

        //---------- เพิ่ม พนักงาน ----------//

        public object CreatEmployee(Employee employee)
        {
            var emp = _employeeRepo.GetByUserName(employee.UserName);
            if (emp != null)
            {
                return new AppResponse{
                    id = 0,
                    code = HttpStatusCode.BadRequest,
                    Message = "This Username exists."
                };
            } 
            else
            {
                string hashed = BCrypt.Net.BCrypt.HashPassword(employee.Password);
                employee.Password = hashed;
                return _employeeRepo.Create(employee);
            }
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

        public Employee? Login(LoginDTO logindto)
        {
            var emp = _employeeRepo.GetByUserName(logindto.UserName);
            if(emp != null)
            {
                bool isValid = BCrypt.Net.BCrypt.Verify(logindto.Password, emp.Password);
                if (isValid)
                {
                    return emp;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}
