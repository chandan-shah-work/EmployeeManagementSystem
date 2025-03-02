using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public int? ReportsToId { get; set; } // Foreign key to self (Manager)
        public Employee ReportsTo { get; set; } // Navigation property for Manager
        public ICollection<Address> Addresses { get; set; } = new List<Address>(); // One-to-Many relationship with Address
    }
}
