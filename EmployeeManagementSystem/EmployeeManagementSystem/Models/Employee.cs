using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeId
        {
            get; set;
        }
        
        [Required(ErrorMessage = "Please enter a name.")]
        // [StringLength(5, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 5 characters.")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters.")]
        public string? EmployeeName
        {
            get; set;
        }
        [Range(20, 50, ErrorMessage = "Age must be between 20 and 50.")]
        [MultipleOfFive(ErrorMessage = "Age must be a multiple of 5.")]
        public int EmployeeAge
        {
            get; set;
        }
    }
}
