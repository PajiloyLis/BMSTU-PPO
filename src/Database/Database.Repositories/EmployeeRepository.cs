using Database.Context;
using Database.Models.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.Core.Exceptions;
using Project.Core.Models;
using Project.Core.Repositories;

namespace Database.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ProjectDbContext _context;
    private readonly ILogger<EmployeeRepository> _logger;

    public EmployeeRepository(ProjectDbContext context, ILogger<EmployeeRepository> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Employee> AddEmployeeAsync(CreationEmployee newEmployee)
    {
        var employee = EmployeeConverter.Convert(newEmployee);
        try
        {
            var foundEmployee = await _context.EmployeeDb
                .Where(u => u.Id == employee.Id || u.Email == employee.Email || u.Phone == employee.Phone)
                .FirstOrDefaultAsync();

            if (employee is not null)
                throw new EmployeeAlreadyExistsException(
                    $"Employee with email - {newEmployee.Email} or phone - {employee.Phone} or id - {employee.Id} already exists");

            await _context.EmployeeDb.AddAsync(employee);
            await _context.SaveChangesAsync();

            return EmployeeConverter.Convert(employee);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error creating employee with id - {employee.Id}");
            throw;
        }
    }

    public async Task DeleteEmployeeAsync(Guid employeeId)
    {
        try
        {
            var employee = await _context.EmployeeDb.FirstOrDefaultAsync(u => u.Id == employeeId);
            if (employee is null) throw new EmployeeNotFoundException($"Employee with id - {employeeId} not found");

            _context.EmployeeDb.Remove(employee);
            await _context.SaveChangesAsync();
        }
        catch (EmployeeNotFoundException e)
        {
            _logger.LogWarning(e, $"Error getting employee with id - {employeeId}");
            throw;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error deleting employee with id - {employeeId}");
            throw;
        }
    }

    public async Task<EmployeePage> GetSubordinatesByDirectorIdAsync(Guid employeeId)
    {
        return new EmployeePage();
    }

    public async Task<Employee> GetEmployeeByIdAsync(Guid employeeId)
    {
        try
        {
            var employee = await _context.EmployeeDb.AsNoTracking().FirstOrDefaultAsync(u => u.Id == employeeId);
            if (employee is null)
                throw new EmployeeNotFoundException($"Employee with id - {employeeId} not found");

            return EmployeeConverter.Convert(employee);
        }
        catch (EmployeeNotFoundException e)
        {
            _logger.LogWarning(e, $"Error getting employee with id - {employeeId}");
            throw;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error getting employee with id - {employeeId}");
            throw;
        }
    }

    public async Task<Employee> UpdateEmployeeAsync(Employee updatedEmployee)
    {
        try
        {
            //Check for users with another Id and same Phone or Email
            var existingEmployeesCount = await _context.EmployeeDb.Where(u => u.Id != updatedEmployee.EmployeeId)
                .Where(u => u.Email == updatedEmployee.Email ||
                            (u.Phone != null && updatedEmployee.PhoneNumber != null &&
                             u.Phone == updatedEmployee.PhoneNumber)).AsNoTracking()
                .CountAsync();

            if (existingEmployeesCount > 0)
                throw new EmployeeAlreadyExistsException(
                    $"Employee with email - {updatedEmployee.Email} or phone - {updatedEmployee.PhoneNumber}");
            var employee = await _context.EmployeeDb.FirstOrDefaultAsync(u => u.Id == updatedEmployee.EmployeeId);
            if (employee is null)
                throw new EmployeeNotFoundException($"Employee with id - {updatedEmployee.EmployeeId} not found");

            employee.Email = updatedEmployee.Email ?? employee.Email;
            employee.Phone = updatedEmployee.PhoneNumber ?? employee.Phone;
            employee.FullName = updatedEmployee.FullName ?? employee.FullName;
            employee.BirthDate = updatedEmployee.BirthDate;
            employee.Photo = updatedEmployee.Photo ?? employee.Photo;
            employee.Duties = updatedEmployee.Duties ?? employee.Duties;

            await _context.SaveChangesAsync();

            return EmployeeConverter.Convert(employee);
        }
        catch (EmployeeNotFoundException e)
        {
            _logger.LogWarning(e, $"Error getting employee with id - {updatedEmployee.EmployeeId}");
            throw;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error updating employee with id - {updatedEmployee.EmployeeId}");
            throw;
        }
    }
}