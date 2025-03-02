using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.API.DTOs
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public int? ReportsToId { get; set; }
        public List<AddressResponse> Addresses { get; set; }
    }

    public class AddressResponse
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string PinCode { get; set; }
    }
}
