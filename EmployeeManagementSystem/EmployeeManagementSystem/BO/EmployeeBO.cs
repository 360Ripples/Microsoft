using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository;

namespace EmployeeManagementSystem.BO
{
    public class EmployeeBO
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeBO(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee AddEmployee(Employee emp)
        {
            return _employeeRepository.SaveEmployee(emp);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }
    }
}
