﻿using Microsoft.Extensions.Logging;
using Project.Core.Exceptions;
using Project.Core.Models;
using Project.Core.Repositories;
using Project.Core.Services;

namespace Project.Services.EmployeeService;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ILogger<EmployeeService> _logger;

    public EmployeeService(IEmployeeRepository employeeRepository, ILogger<EmployeeService> logger)
    {
        _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Employee> AddEmployeeAsync(string fullName, string? phoneNumber, string email, DateOnly birthday,
        string? photoPath, string? duties)
    {
        try
        {
            var employee = await _employeeRepository.AddEmployeeAsync(new CreationEmployee(fullName, phoneNumber, email,
                birthday,
                photoPath, duties));

            return employee;
        }
        catch (EmployeeAlreadyExistsException e)
        {
            _logger.LogWarning(e,
                $"Employee with email - {email} or phone number - {phoneNumber} or generated id already exists");
            throw;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error creating employee with email - {email} and phone number - {phoneNumber}");
            throw;
        }
    }

    public async Task<Employee> UpdateEmployeeAsync(Guid id, string? fullName, string? phoneNumber, string? email,
        DateOnly? birthday,
        string? photoPath, string? duties)
    {
        try
        {
            var employee = await _employeeRepository.UpdateEmployeeAsync(new UpdateEmployee(id, fullName, phoneNumber,
                email,
                birthday,
                photoPath, duties));

            return employee;
        }
        catch (EmployeeAlreadyExistsException e)
        {
            _logger.LogWarning(e, "Employee with such parameters already exists");
            throw;
        }
        catch (EmployeeNotFoundException e)
        {
            _logger.LogWarning(e, $"Employee with id - {id} not found");
            throw;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error updating employee with id - {id}");
            throw;
        }
    }

    public async Task DeleteEmployeeAsync(Guid employeeId)
    {
        try
        {
            await _employeeRepository.DeleteEmployeeAsync(employeeId);
        }
        catch (EmployeeNotFoundException e)
        {
            _logger.LogWarning(e, $"Employee with id - {employeeId} not found");
            throw;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error deleting employee with id - {employeeId}");
            throw;
        }
    }

    public async Task<Employee> GetEmployeeByIdAsync(Guid id)
    {
        try
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            return employee;
        }
        catch (EmployeeNotFoundException e)
        {
            _logger.LogWarning(e, $"Employee with id - {id} not found");
            throw;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error getting employee with id - {id}");
            throw;
        }
    }

    public async Task<EmployeePage> GetSubordinatesByDirectorIdAsync(Guid directorId)
    {
        try
        {
            var employees = await _employeeRepository.GetSubordinatesByDirectorIdAsync(directorId);
            return employees;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error getting employees by director id - {directorId}");
            throw;
        }
    }
}