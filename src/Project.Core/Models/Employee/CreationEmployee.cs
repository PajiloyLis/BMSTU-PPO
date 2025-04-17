namespace Project.Core.Models;

public class CreationEmployee
{
    public CreationEmployee(string fullName,
        string phoneNumber,
        string email,
        DateOnly birthDate,
        string? photo,
        string? duties
    )
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
        BirthDate = birthDate;
        Photo = photo;
        Duties = duties;
    }

    public string FullName { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public DateOnly BirthDate { get; set; }

    public string? Photo { get; set; }

    public string? Duties { get; set; }
}