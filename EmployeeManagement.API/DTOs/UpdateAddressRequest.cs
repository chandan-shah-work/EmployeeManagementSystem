using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.API.DTOs
{
    public class UpdateAddressRequest
    {
        public int Id { get; set; } // Address ID
        public string City { get; set; }
        public string Area { get; set; }
        public string PinCode { get; set; }
        public int EmployeeId { get; set; } // Add EmployeeId to ensure foreign key constraint
    }
}
