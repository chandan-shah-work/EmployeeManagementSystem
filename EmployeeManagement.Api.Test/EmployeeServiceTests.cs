using EmployeeManagement.API.Models;
using EmployeeManagement.API.Repository.Interfaces;
using EmployeeManagement.API.Service.Implementations;
using EmployeeManagement.API.Service.Interfaces;
using EmployeeManagement.Api.Test.TestData;
using Moq;
using FluentAssertions;

namespace EmployeeManagement.Api.Test
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;
        private readonly IEmployeeService _employeeService;

        public EmployeeServiceTests()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _employeeService = new EmployeeService(_mockEmployeeRepository.Object);
        }

        [Fact]
        public async Task SaveEmployeeAsync_ShouldReturnSavedEmployee()
        {
            // Arrange
            var employee = EmployeeTestData.GetEmployee();
            _mockEmployeeRepository.Setup(repo => repo.SaveEmployeeAsync(It.IsAny<Employee>()))
                .ReturnsAsync(employee);

            // Act
            var result = await _employeeService.SaveEmployeeAsync(employee);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(employee.Id);
            result.FirstName.Should().Be(employee.FirstName);
            result.LastName.Should().Be(employee.LastName);
            _mockEmployeeRepository.Verify(repo => repo.SaveEmployeeAsync(It.IsAny<Employee>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAddressAsync_ShouldCallRepository()
        {
            // Arrange
            var address = new Address { Id = 1, City = "Mumbai", Area = "Bandra", PinCode = "400050", EmployeeId = 1 };
            _mockEmployeeRepository.Setup(repo => repo.UpdateAddressAsync(It.IsAny<Address>()))
                .Returns(Task.CompletedTask);

            // Act
            await _employeeService.UpdateAddressAsync(address);

            // Assert
            _mockEmployeeRepository.Verify(repo => repo.UpdateAddressAsync(It.IsAny<Address>()), Times.Once);
        }

        [Fact]
        public async Task GetAddressesByEmployeeIdAsync_ShouldReturnAddresses()
        {
            // Arrange
            var employeeId = 1;
            var addresses = new List<Address>
            {
                new Address { Id = 1, City = "Mumbai", Area = "Bandra", PinCode = "400050", EmployeeId = employeeId },
                new Address { Id = 2, City = "Mumbai", Area = "Andheri", PinCode = "400053", EmployeeId = employeeId }
            };
            _mockEmployeeRepository.Setup(repo => repo.GetAddressesByEmployeeIdAsync(employeeId))
                .ReturnsAsync(addresses);

            // Act
            var result = await _employeeService.GetAddressesByEmployeeIdAsync(employeeId);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(2);
            result.Should().BeEquivalentTo(addresses);
            _mockEmployeeRepository.Verify(repo => repo.GetAddressesByEmployeeIdAsync(employeeId), Times.Once);
        }

        [Fact]
        public async Task GetEmployeesByManagerIdAsync_ShouldReturnEmployees()
        {
            // Arrange
            var managerId = 1;
            var employees = EmployeeTestData.GetEmployees();
            _mockEmployeeRepository.Setup(repo => repo.GetEmployeesByManagerIdAsync(managerId))
                .ReturnsAsync(employees);

            // Act
            var result = await _employeeService.GetEmployeesByManagerIdAsync(managerId);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(2);
            result.Should().BeEquivalentTo(employees);
            _mockEmployeeRepository.Verify(repo => repo.GetEmployeesByManagerIdAsync(managerId), Times.Once);
        }

        [Fact]
        public async Task GetManagerByEmployeeIdAsync_ShouldReturnManager()
        {
            // Arrange
            var employeeId = 2;
            var manager = new Employee { Id = 1, FirstName = "Ramesh", LastName = "Kumar", Designation = "Software Engineer" };
            _mockEmployeeRepository.Setup(repo => repo.GetManagerByEmployeeIdAsync(employeeId))
                .ReturnsAsync(manager);

            // Act
            var result = await _employeeService.GetManagerByEmployeeIdAsync(employeeId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(manager.Id);
            result.FirstName.Should().Be(manager.FirstName);
            result.LastName.Should().Be(manager.LastName);
            _mockEmployeeRepository.Verify(repo => repo.GetManagerByEmployeeIdAsync(employeeId), Times.Once);
        }
    }
}