using Project.Core.Models;

namespace Project.Core.Repositories;

public interface IEmployeeRepository
{
    Task<Employee> AddEmployeeAsync(CreationEmployee newEmployee);

    Task<Employee> UpdateEmployeeAsync(UpdateEmployee updateEmployee);

    Task<Employee> GetEmployeeByIdAsync(Guid employeeId);

    Task<EmployeePage> GetSubordinatesByDirectorIdAsync(Guid directorId);

    Task DeleteEmployeeAsync(Guid employeeId);
}