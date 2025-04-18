namespace Database.Models;

/// <summary>
/// Database company model
/// </summary>
public class CompanyDb
{
    public CompanyDb(Guid companyId,
        string title,
        DateOnly registrationDate,
        string phoneNumber,
        string email,
        string inn,
        string kpp,
        string ogrn,
        string address
    )
    {
        CompanyId = companyId;
        Title = title;
        RegistrationDate = registrationDate;
        PhoneNumber = phoneNumber;
        Email = email;
        Inn = inn;
        Kpp = kpp;
        Ogrn = ogrn;
        Address = address;
    }

    /// <summary>
    /// Company id
    /// </summary>
    public Guid CompanyId { get; init; }

    /// <summary>
    /// Company name
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Company registration date
    /// </summary>
    public DateOnly RegistrationDate { get; set; }

    /// <summary>
    /// Company contact phone number
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Company contact email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Company inn
    /// </summary>
    public string Inn { get; set; }

    /// <summary>
    /// Company kpp
    /// </summary>
    public string Kpp { get; set; }

    /// <summary>
    /// Company ogrn
    /// </summary>
    public string Ogrn { get; set; }

    /// <summary>
    /// Company registered address
    /// </summary>
    public string Address { get; set; }
}