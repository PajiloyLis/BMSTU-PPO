using System.Diagnostics.CodeAnalysis;
using Project.Core.Models;

namespace Project.Dto.Http.Converters;

public static class EmployeeConverter
{
    [return: NotNullIfNotNull(nameof(employee))]
    public static EmployeeDto? Convert(Employee? employee)
    {
        if (employee is null)
            return null;

        return new EmployeeDto(employee.EmployeeId,
            employee.FullName,
            employee.PhoneNumber,
            employee.Email,
            employee.BirthDate,
            employee.Photo,
            employee.Duties
        );
    }
}