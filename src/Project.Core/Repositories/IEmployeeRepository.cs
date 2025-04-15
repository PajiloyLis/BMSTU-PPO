using Project.Core.Models;

namespace Project.Core.Repositories;

public interface IEmployeeRepository
{
    public Task<Employee> AddEmployeeAsync(CreationEmployee newEmployee);

    public Task<Employee> UpdateEmployeeAsync(Employee employee);

    public Task<Employee> GetEmployeeByIdAsync(Guid employeeId);

    public Task<EmployeePage> GetSubordinatesByDirectorIdAsync(Guid directorId);

    public Task DeleteEmployeeAsync(Guid employeeId);
}