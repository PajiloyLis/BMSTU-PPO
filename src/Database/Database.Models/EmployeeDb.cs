namespace Database.Models;

/// <summary>
/// Database employee model.
/// </summary>
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

    /// <summary>
    /// Employee id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Employee full name.
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Employee business phone number.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Employee business email.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Employee birthday.
    /// </summary>
    public DateOnly BirthDate { get; set; }

    /// <summary>
    /// Employee photo path.
    /// </summary>
    public string? Photo { get; set; }

    /// <summary>
    /// Employee duties json formated
    /// </summary>
    public string? Duties { get; set; }
}