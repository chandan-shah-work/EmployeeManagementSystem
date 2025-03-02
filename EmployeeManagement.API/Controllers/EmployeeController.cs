using EmployeeManagement.API.DTOs;
using EmployeeManagement.API.Models;
using EmployeeManagement.API.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveEmployee([FromBody] SaveEmployeeRequest request)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Designation = request.Designation,
                ReportsToId = request.ReportsToId,
                Addresses = request.Addresses.ConvertAll(a => new Address
                {
                    City = a.City,
                    Area = a.Area,
                    PinCode = a.PinCode
                })
            };

            var savedEmployee = await _employeeService.SaveEmployeeAsync(employee);

            // Map the saved Employee to EmployeeResponse
            var response = new EmployeeResponse
            {
                Id = savedEmployee.Id,
                FirstName = savedEmployee.FirstName,
                LastName = savedEmployee.LastName,
                Designation = savedEmployee.Designation,
                ReportsToId = savedEmployee.ReportsToId,
                Addresses = savedEmployee.Addresses.Select(a => new AddressResponse
                {
                    Id = a.Id,
                    City = a.City,
                    Area = a.Area,
                    PinCode = a.PinCode
                }).ToList()
            };

            return Ok(response);
        }

        [HttpPut("address/update")]
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressRequest request)
        {
            var address = new Address
            {
                Id = request.Id,
                City = request.City,
                Area = request.Area,
                PinCode = request.PinCode,
                EmployeeId = request.EmployeeId
            };

            await _employeeService.UpdateAddressAsync(address);
            return Ok("Address Updated Sucessfully");
        }

        [HttpGet("{employeeId}/addresses")]
        public async Task<IActionResult> GetAddresses(int employeeId)
        {
            var addresses = await _employeeService.GetAddressesByEmployeeIdAsync(employeeId);
            return Ok(addresses);
        }

        [HttpGet("manager/{managerId}/employees")]
        public async Task<IActionResult> GetEmployeesByManager(int managerId)
        {
            var employees = await _employeeService.GetEmployeesByManagerIdAsync(managerId);
            return Ok(employees);
        }

        [HttpGet("{employeeId}/manager")]
        public async Task<IActionResult> GetManager(int employeeId)
        {
            var manager = await _employeeService.GetManagerByEmployeeIdAsync(employeeId);
            return Ok(manager);
        }
    }
}
