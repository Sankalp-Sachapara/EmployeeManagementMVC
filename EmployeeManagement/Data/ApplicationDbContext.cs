using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Employee entity
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18,2)");

            // Optional: Seed some initial data
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    JobTitle = "Software Developer",
                    Salary = 75000
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    JobTitle = "Project Manager",
                    Salary = 85000
                },
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Michael",
                    LastName = "Johnson",
                    JobTitle = "UX Designer",
                    Salary = 70000
                }
            );
        }
    }
}
