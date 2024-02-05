using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class MultipleOfFiveAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int employeeAge = (int)value;

                if (employeeAge % 5 == 0)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Age must be a multiple of 5.");
                }
            }

            return ValidationResult.Success; // You can change this based on your specific requirements.
        }
    }
}