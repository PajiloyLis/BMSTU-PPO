using System.Diagnostics.CodeAnalysis;
using Project.Core.Models;

namespace Database.Models.Converters;

public static class EmployeeConverter
{
    [return: NotNullIfNotNull(nameof(employee))]
    public static Employee? Convert(EmployeeDb? employee)
    {
        if (employee is null) return null;

        return new Employee(employee.Id,
            employee.FullName,
            employee.Phone,
            employee.Email,
            employee.BirthDate,
            employee.Photo,
            employee.Duties
        );
    }

    // [return: NotNullIfNotNull(nameof(employee))]
    // public static EmployeeDb? Convert(UpdateEmployee? employee)
    // {
    //     if (employee == null)
    //         return null;
    //
    //     return new EmployeeDb(employee.EmployeeId,
    //         employee.FullName,
    //         employee.PhoneNumber,
    //         employee.Email,
    //         employee.BirthDate,
    //         employee.Photo,
    //         employee.Duties
    //     );
    // }

    [return: NotNullIfNotNull(nameof(employee))]
    public static EmployeeDb? Convert(CreationEmployee? employee)
    {
        if (employee == null)
            return null;

        return new EmployeeDb(Guid.NewGuid(),
            employee.FullName,
            employee.PhoneNumber,
            employee.Email,
            employee.BirthDate,
            employee.Photo,
            employee.Duties
        );
    }

    [return: NotNullIfNotNull(nameof(employee))]
    public static EmployeeDb? Convert(Employee? employee)
    {
        if (employee == null)
            return null;

        return new EmployeeDb(Guid.NewGuid(),
            employee.FullName,
            employee.PhoneNumber,
            employee.Email,
            employee.BirthDate,
            employee.Photo,
            employee.Duties
        );
    }
}