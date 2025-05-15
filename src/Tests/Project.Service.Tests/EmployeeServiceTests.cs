using Microsoft.Extensions.Logging;
using Moq;
using Project.Core.Exceptions;
using Project.Core.Models;
using Project.Core.Repositories;
using Project.Services.EmployeeService;
using Xunit;

public class EmployeeServiceTests
{
    private readonly EmployeeService _employeeService;
    private readonly Mock<ILogger<EmployeeService>> _mockLogger;
    private readonly Mock<IEmployeeRepository> _mockRepo;

    public EmployeeServiceTests()
    {
        _mockRepo = new Mock<IEmployeeRepository>();
        _mockLogger = new Mock<ILogger<EmployeeService>>();
        _employeeService = new EmployeeService(_mockRepo.Object, _mockLogger.Object);
    }

    [Fact]
    public async Task AddEmployee_Successful_1()
    {
        // Arrange
        var employeeToAdd = new CreationEmployee(
            "John Doe",
            "+1234567890",
            "john.doe@example.com",
            new DateOnly(1990, 1, 1),
            "photo.jpg",
            "{[1: \"Developer\"]}"
        );

        var expectedEmployee = new Employee(
            Guid.NewGuid(),
            "John Doe",
            "+1234567890",
            "john.doe@example.com",
            new DateOnly(1990, 1, 1),
            "photo.jpg",
            "{[1: \"Developer\"]}");

        _mockRepo.Setup(expr => expr.AddEmployeeAsync(It.IsAny<CreationEmployee>())).ReturnsAsync(expectedEmployee);

        // Act
        var result = await _employeeService.AddEmployeeAsync("John Doe",
            "+1234567890",
            "john.doe@example.com",
            new DateOnly(1990, 1, 1),
            "photo.jpg",
            "{[1: \"Developer\"]}");

        // Assert
        Assert.Equal(expectedEmployee, result);
        Assert.Equal(employeeToAdd.FullName, result.FullName);
        Assert.Equal(employeeToAdd.Email, result.Email);
        Assert.Equal(employeeToAdd.PhoneNumber, result.PhoneNumber);
        Assert.Equal(employeeToAdd.BirthDate, result.BirthDate);
        Assert.NotNull(result.Duties);
        Assert.NotNull(result.Photo);
        Assert.Equal(employeeToAdd.Duties, result.Duties);
        Assert.Equal(employeeToAdd.Photo, result.Photo);
        _mockRepo.Verify(expr => expr.AddEmployeeAsync(It.IsAny<CreationEmployee>()), Times.Once);
    }

    [Fact]
    public async Task AddEmployee_Successful_2()
    {
        // Arrange
        var employeeToAdd = new CreationEmployee(
            "John Doe",
            "+1234567890",
            "john.doe@example.com",
            new DateOnly(1990, 1, 1),
            "photo.jpg",
            null
        );

        var expectedEmployee = new Employee(
            Guid.NewGuid(),
            "John Doe",
            "+1234567890",
            "john.doe@example.com",
            new DateOnly(1990, 1, 1),
            "photo.jpg",
            null);

        _mockRepo.Setup(expr => expr.AddEmployeeAsync(It.IsAny<CreationEmployee>())).ReturnsAsync(expectedEmployee);

        // Act
        var result = await _employeeService.AddEmployeeAsync("John Doe",
            "+1234567890",
            "john.doe@example.com",
            new DateOnly(1990, 1, 1),
            "photo.jpg",
            null);

        // Assert
        Assert.Equal(expectedEmployee, result);
        Assert.Equal(employeeToAdd.FullName, result.FullName);
        Assert.Equal(employeeToAdd.Email, result.Email);
        Assert.Equal(employeeToAdd.PhoneNumber, result.PhoneNumber);
        Assert.Equal(employeeToAdd.BirthDate, result.BirthDate);
        Assert.Null(result.Duties);
        Assert.NotNull(result.Photo);
        Assert.Equal(employeeToAdd.Duties, result.Duties);
        Assert.Equal(employeeToAdd.Photo, result.Photo);
        _mockRepo.Verify(expr => expr.AddEmployeeAsync(It.IsAny<CreationEmployee>()), Times.Once);
    }

    [Fact]
    public async Task AddEmployee_Successful_3()
    {
        // Arrange
        var employeeToAdd = new CreationEmployee(
            "John Doe",
            "+1234567890",
            "john.doe@example.com",
            new DateOnly(1990, 1, 1),
            null,
            null
        );

        var expectedEmployee = new Employee(
            Guid.NewGuid(),
            "John Doe",
            "+1234567890",
            "john.doe@example.com",
            new DateOnly(1990, 1, 1),
            null,
            null);

        _mockRepo.Setup(expr => expr.AddEmployeeAsync(It.IsAny<CreationEmployee>())).ReturnsAsync(expectedEmployee);

        // Act
        var result = await _employeeService.AddEmployeeAsync("John Doe",
            "+1234567890",
            "john.doe@example.com",
            new DateOnly(1990, 1, 1),
            null,
            null);

        // Assert
        Assert.Equal(expectedEmployee, result);
        Assert.Equal(employeeToAdd.FullName, result.FullName);
        Assert.Equal(employeeToAdd.Email, result.Email);
        Assert.Equal(employeeToAdd.PhoneNumber, result.PhoneNumber);
        Assert.Equal(employeeToAdd.BirthDate, result.BirthDate);
        Assert.Null(result.Duties);
        Assert.Null(result.Photo);
        Assert.Equal(employeeToAdd.Duties, result.Duties);
        Assert.Equal(employeeToAdd.Photo, result.Photo);
        _mockRepo.Verify(expr => expr.AddEmployeeAsync(It.IsAny<CreationEmployee>()), Times.Once);
    }

    [Fact]
    public async Task AddEmployee_NameValidationFailed()
    {
        // Arrange
        var expectedEmployee = new Employee(
            Guid.NewGuid(),
            "John Doe",
            "+1234567890",
            "john.doe@example.com",
            new DateOnly(1990, 1, 1),
            null,
            null);

        _mockRepo.Setup(expr => expr.AddEmployeeAsync(It.IsAny<CreationEmployee>())).ReturnsAsync(expectedEmployee);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _employeeService.AddEmployeeAsync("John Doe1",
            "+1234567890",
            "john.doe@example.com",
            new DateOnly(1990, 1, 1),
            null,
            null)
        );

        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Employee with incorrect parameters passed")),
                It.Is<ArgumentException>(e => e.Message.Contains("Invalid employee name")),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()
            ),
            Times.Once
        );
    }

    [Fact]
    public async Task AddEmployee_EmployeeAlreadyExists()
    {
        // Arrange
        _mockRepo.Setup(r => r.AddEmployeeAsync(It.IsAny<CreationEmployee>()))
            .ThrowsAsync(new EmployeeAlreadyExistsException("Employee already exists"));

        // Act & Assert
        await Assert.ThrowsAsync<EmployeeAlreadyExistsException>(() =>
            _employeeService.AddEmployeeAsync(
                "John Doe",
                "+1234567890",
                "john.doe@example.com",
                new DateOnly(1990, 1, 1),
                "photo.jpg",
                "Developer"
            )
        );

        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Employee with email")),
                It.Is<EmployeeAlreadyExistsException>(e => e.Message.Contains("already exists")),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()
            ),
            Times.Once
        );
    }
}