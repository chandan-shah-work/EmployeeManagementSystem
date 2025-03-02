﻿using EmployeeManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> SaveEmployeeAsync(Employee employee);
        Task UpdateAddressAsync(Address address);
        Task<List<Address>> GetAddressesByEmployeeIdAsync(int employeeId);
        Task<List<Employee>> GetEmployeesByManagerIdAsync(int managerId);
        Task<Employee> GetManagerByEmployeeIdAsync(int employeeId);
    }
}
