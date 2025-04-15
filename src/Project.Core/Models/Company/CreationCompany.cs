namespace Project.Core.Models;

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

    public string Title { get; set; }

    public DateOnly RegistrationDate { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Inn { get; set; }

    public string Kpp { get; set; }

    public string Ogrn { get; set; }

    public string Address { get; set; }
}