namespace Project.Core.Models;

/// <summary>
/// Company creation model
/// </summary>
public class CreationCompany
{
    public CreationCompany(string title,
        DateOnly registrationDate,
        string phoneNumber,
        string email,
        string inn,
        string kpp,
        string ogrn,
        string address
    )
    {
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
    /// Company's name
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Company's registration date
    /// </summary>
    public DateOnly RegistrationDate { get; set; }

    /// <summary>
    /// Company's contact phone number
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Company's contact email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Company's inn
    /// </summary>
    public string Inn { get; set; }

    /// <summary>
    /// Company's kpp
    /// </summary>
    public string Kpp { get; set; }

    /// <summary>
    /// Company's ogrn
    /// </summary>
    public string Ogrn { get; set; }

    /// <summary>
    /// Company's registered address
    /// </summary>
    public string Address { get; set; }
}