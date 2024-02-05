using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repository
{
    public interface IEmployeeRepository
    {
        Employee SaveEmployee(Employee emp);
        IEnumerable<Employee> GetAllEmployees();
    }
}
