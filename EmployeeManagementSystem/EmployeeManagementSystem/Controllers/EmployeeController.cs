using EmployeeManagementSystem.BO;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeBO _employeeBO;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeBO = new EmployeeBO(employeeRepository);
        }

        public IActionResult Index()
        {
            var employees = _employeeBO.GetAllEmployees();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                var createdEmployee = _employeeBO.AddEmployee(emp);
                return RedirectToAction("Details", new
                {
                    id = createdEmployee.EmployeeId
                });
            }

            return View(emp);
        }

        public IActionResult Details(int id)
        {
            var employee = _employeeBO.GetAllEmployees().FirstOrDefault(e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
    }
}