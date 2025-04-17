namespace Database.Models;

public class EmployeeDb
{
    public EmployeeDb(Guid id,
        string fullName,
        string phone,
        string email,
        DateOnly birthDate,
        string? photo,
        string? duties)
    {
        Id = id;
        FullName = fullName;
        Phone = phone;
        Email = email;
        BirthDate = birthDate;
        Photo = photo;
        Duties = duties;
    }

    public Guid Id { get; set; }

    public string FullName { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public DateOnly BirthDate { get; set; }

    public string? Photo { get; set; }

    public string? Duties { get; set; }
}