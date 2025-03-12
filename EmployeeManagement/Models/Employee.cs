using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [Display(Name = "Salary")]
        public decimal Salary { get; set; }

        // Constructor to initialize string properties
        public Employee()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            JobTitle = string.Empty;
        }

        // Computed property for full name
        [Display(Name = "Employee Name")]
        public string FullName 
        { 
            get { return FirstName + " " + LastName; }
        }
    }
}
