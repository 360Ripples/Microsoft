using EmployeeManagementSystem.BO;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;



namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private readonly EmployeeBO _employeeBO;
        public EmployeeApiController(IEmployeeRepository employeeRepository)
        {
            _employeeBO = new EmployeeBO(employeeRepository);
        }
        // GET: api/<EmployeeApiController>
        [HttpGet]
        public IActionResult Get()
        {
            var employees = _employeeBO.GetAllEmployees();
            return Ok(employees);
        }

        //https://localhost:7083/api/EmployeeApi/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _employeeBO.GetAllEmployees().FirstOrDefault(e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound("Employee Id does not Exist");
            }

            return Ok(employee);
        }

        //https://localhost:7083/api/EmployeeApi
        [HttpPost]
        public IActionResult InsertEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                var createdEmployee = _employeeBO.AddEmployee(emp);
                return CreatedAtAction(nameof(Get), new
                {
                    id = createdEmployee.EmployeeId
                }, createdEmployee);
            }

            return BadRequest(ModelState);
        }
    
    }
}
