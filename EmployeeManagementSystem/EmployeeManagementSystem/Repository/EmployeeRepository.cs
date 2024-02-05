using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static List<Employee> _employeeList = new List<Employee>();
      public Employee SaveEmployee(Employee emp)
        {
            emp.EmployeeId = _employeeList.Count + 1;
            _employeeList.Add(emp);
            return emp;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }
    }
}

