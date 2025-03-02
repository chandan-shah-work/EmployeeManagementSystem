using EmployeeManagement.API.DBContext;
using EmployeeManagement.API.Models;
using EmployeeManagement.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Repository.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> SaveEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task UpdateAddressAsync(Address address)
        {
            var existingAddress = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == address.Id);

            if (existingAddress == null)
            {
                throw new KeyNotFoundException("Address not found.");
            }

            // Update the fields
            existingAddress.City = address.City;
            existingAddress.Area = address.Area;
            existingAddress.PinCode = address.PinCode;
            existingAddress.EmployeeId = address.EmployeeId; // Ensure EmployeeId is updated

            _context.Addresses.Update(existingAddress);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Address>> GetAddressesByEmployeeIdAsync(int employeeId)
        {
            return await _context.Addresses
                .Where(a => a.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeesByManagerIdAsync(int managerId)
        {
            return await _context.Employees
                .Where(e => e.ReportsToId == managerId)
                .ToListAsync();
        }

        public async Task<Employee> GetManagerByEmployeeIdAsync(int employeeId)
        {
            var employee = await _context.Employees
                .Include(e => e.ReportsTo)
                .FirstOrDefaultAsync(e => e.Id == employeeId);
            return employee?.ReportsTo;
        }
    }
}
