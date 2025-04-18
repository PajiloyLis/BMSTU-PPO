using Project.Core.Models;

namespace Project.Core.Services;

public interface ICompanyService
{
    Task<Company> AddCompanyAsync(string title, DateOnly registrationDate, string phoneNumber,
        string email, string inn, string kpp, string ogrn, string address);

    Task<Company> GetCompanyByIdAsync(Guid companyId);

    Task<Company> UpdateCompanyAsync(Guid companyId, string? title, DateOnly? registrationDate, string? phoneNumber,
        string? email, string? inn, string? kpp, string? ogrn, string? address);

    Task<CompanyPage> GetCompaniesAsync(int pageNumber, int pageSize);

    Task DeleteCompanyAsync(Guid companyId);
}