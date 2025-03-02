using EmployeeManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Test.TestData
{
    public class EmployeeTestData
    {
        public static Employee GetEmployee()
        {
            return new Employee
            {
                Id = 1,
                FirstName = "Ramesh",
                LastName = "Kumar",
                Designation = "Software Engineer",
                ReportsToId = null,
                Addresses = new List<Address>
                {
                    new Address { Id = 1, City = "Mumbai", Area = "Bandra", PinCode = "400050" },
                    new Address { Id = 2, City = "Mumbai", Area = "Andheri", PinCode = "400053" }
                }
            };
        }

        public static List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "Ramesh",
                    LastName = "Kumar",
                    Designation = "Senior Manager",
                    ReportsToId = null
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Suresh",
                    LastName = "Singh",
                    Designation = "Senior Developer",
                    ReportsToId = 1
                }
            };
        }
    }
}
