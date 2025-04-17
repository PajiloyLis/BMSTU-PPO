namespace Project.Core.Models;

public class UpdateEmployee
{
    public UpdateEmployee(Guid employeeId,
        string? fullName,
        string? phoneNumber,
        string? email,
        DateOnly? birthDate,
        string? photo,
        string? duties
    )
    {
        EmployeeId = employeeId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
        BirthDate = birthDate;
        Photo = photo;
        Duties = duties;
    }

    public UpdateEmployee()
    {
    }

    public Guid EmployeeId { get; set; }

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Photo { get; set; }

    public string? Duties { get; set; }
}