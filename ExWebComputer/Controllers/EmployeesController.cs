using ExWebComputer.DTOs;
using ExWebComputer.Model;
using ExWebComputer.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExWebComputer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        //---------- การ injection ----------//

        public EmployeesController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }

        //---------- ค้นหา พนักงาน ----------//

        [HttpGet]
        public ActionResult GetEmployees([FromQuery] string? search, int? page, int? per_page)
        {
            return Ok(_employeeService.GetEmployees(search, page, per_page));
        }

        //---------- ค้นหา พนักงาน ด้วย id ----------//

        [HttpGet("{id}")]
        public ActionResult GetEmployee(int id)
        {
            Employee? employee = _employeeService.GetEmployee(id);
            if (employee == null) return NotFound("Employee Notfound");
            return Ok(employee);
        }

        //---------- เพิ่ม พนักงาน ----------//

        [HttpPost]
        public ActionResult AddEmployee([FromBody] Employee employee)
        {
            var addedEmployee = _employeeService.CreatEmployee(employee);
            if (addedEmployee.GetType() == typeof(AppResponse))
            {
                return BadRequest(addedEmployee);
            }
            else
            {
                return CreatedAtAction(nameof(AddEmployee), addedEmployee);
            }
        }

        //---------- แก้ไข พนักงาน ----------//

        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, Employee employee)
        {
            if (employee.Id == id)
            {
                var update = _employeeService.UpdateEmployee(employee);
                return Ok(update);
            }
            return BadRequest("update filed");
        }

        //---------- ลบ พนักงาน ----------//

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            Employee? employee = _employeeService.DeleteEmployee(id);
            if (employee == null) return NotFound("Employee Notfound");
            return NoContent();
        }

        //---------- เข้าสู่ระบบ ----------//

        [HttpPost("Login")]
        public ActionResult Login(LoginDTO logindto)
        {
            Employee? employee = _employeeService.Login(logindto);
            if (employee == null) return BadRequest(                
                new AppResponse {
                        id = 0,
                        code = HttpStatusCode.BadRequest,
                        Message = "Login filed"
                    }
                );
            return Ok(employee);
        }
    }
}
