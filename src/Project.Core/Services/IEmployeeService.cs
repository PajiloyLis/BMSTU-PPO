using Project.Core.Models;

namespace Project.Core.Services;

public interface IEmployeeService
{
    Task<Employee> AddEmployeeAsync(string fullName, string phoneNumber, string email, DateOnly birthday,
        string? photoPath,
        string? duties);

    Task<Employee> UpdateEmployeeAsync(Guid id, string? fullName, string? phoneNumber, string? email,
        DateOnly? birthday,
        string? photoPath, string? duties);

    Task<Employee> GetEmployeeByIdAsync(Guid userId);

    Task<EmployeePage> GetSubordinatesByDirectorIdAsync(Guid directorId);

    Task DeleteEmployeeAsync(Guid userId);
}