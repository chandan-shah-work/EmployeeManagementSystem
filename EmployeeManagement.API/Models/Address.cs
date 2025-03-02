using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string PinCode { get; set; }
        public int EmployeeId { get; set; } // Foreign key to Employee
        public Employee Employee { get; set; } // Navigation property
    }
}
