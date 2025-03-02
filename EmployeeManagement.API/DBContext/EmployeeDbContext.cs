using EmployeeManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.DBContext
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-many relationship between Employee and Address
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Addresses)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId);

            // Configure self-referencing relationship for Manager
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.ReportsTo)
                .WithMany()
                .HasForeignKey(e => e.ReportsToId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Seed data for Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Ramesh",
                    LastName = "Kumar",
                    Designation = "Senior Manager",
                    ReportsToId = null // No manager
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Suresh",
                    LastName = "Singh",
                    Designation = "Senior Developer",
                    ReportsToId = 1 // Reports to Ramesh
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Priya",
                    LastName = "Sharma",
                    Designation = "Junior Developer",
                    ReportsToId = 2 // Reports to Suresh
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Anjali",
                    LastName = "Gupta",
                    Designation = "QA Engineer",
                    ReportsToId = 1 // Reports to Ramesh
                },
                new Employee
                {
                    Id = 5,
                    FirstName = "Rajesh",
                    LastName = "Patel",
                    Designation = "DevOps Engineer",
                    ReportsToId = 1 // Reports to Ramesh
                }
            );

            // Seed data for Addresses
            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    City = "Mumbai",
                    Area = "Bandra",
                    PinCode = "400050",
                    EmployeeId = 1 // Address for Ramesh
                },
                new Address
                {
                    Id = 2,
                    City = "Delhi",
                    Area = "Connaught Place",
                    PinCode = "110001",
                    EmployeeId = 2 // Address for Suresh
                },
                new Address
                {
                    Id = 3,
                    City = "Bangalore",
                    Area = "Koramangala",
                    PinCode = "560034",
                    EmployeeId = 3 // Address for Priya
                },
                new Address
                {
                    Id = 4,
                    City = "Hyderabad",
                    Area = "Gachibowli",
                    PinCode = "500032",
                    EmployeeId = 4 // Address for Anjali
                },
                new Address
                {
                    Id = 5,
                    City = "Pune",
                    Area = "Hinjewadi",
                    PinCode = "411057",
                    EmployeeId = 5 // Address for Rajesh
                },
                new Address
                {
                    Id = 6,
                    City = "Mumbai",
                    Area = "Andheri",
                    PinCode = "400053",
                    EmployeeId = 1 // Second address for Ramesh
                },
                new Address
                {
                    Id = 7,
                    City = "Delhi",
                    Area = "Saket",
                    PinCode = "110017",
                    EmployeeId = 2 // Second address for Suresh
                },
                new Address
                {
                    Id = 8,
                    City = "Bangalore",
                    Area = "Indiranagar",
                    PinCode = "560038",
                    EmployeeId = 3 // Second address for Priya
                }
            );
        }
    }
}
