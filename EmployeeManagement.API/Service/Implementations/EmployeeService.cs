using EmployeeManagement.API.Models;
using EmployeeManagement.API.Repository.Interfaces;
using EmployeeManagement.API.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Service.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> SaveEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.SaveEmployeeAsync(employee);
        }

        public async Task UpdateAddressAsync(Address address)
        {
            await _employeeRepository.UpdateAddressAsync(address);
        }

        public async Task<List<Address>> GetAddressesByEmployeeIdAsync(int employeeId)
        {
            return await _employeeRepository.GetAddressesByEmployeeIdAsync(employeeId);
        }

        public async Task<List<Employee>> GetEmployeesByManagerIdAsync(int managerId)
        {
            return await _employeeRepository.GetEmployeesByManagerIdAsync(managerId);
        }

        public async Task<Employee> GetManagerByEmployeeIdAsync(int employeeId)
        {
            return await _employeeRepository.GetManagerByEmployeeIdAsync(employeeId);
        }

    }
}
