using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.API.DTOs
{
    public class SaveEmployeeRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public int? ReportsToId { get; set; } // Manager's ID (nullable)
        public List<AddressDto> Addresses { get; set; } // List of addresses
    }

    public class AddressDto
    {
        public string City { get; set; }
        public string Area { get; set; }
        public string PinCode { get; set; }
    }
}
