using Project.Core.Models;

namespace Project.Core.Repositories;

public interface ICompanyRepository
{
    public Task<Company> AddCompanyAsync(CreationCompany newCompany);

    public Task<Company> GetCompanyByIdAsync(Guid companyId);

    public Task<Company> UpdateCompanyAsync(Company company);

    public Task<CompanyPage> GetCompaniesAsync(int pageNumber, int pageSize);

    public Task DeleteCompanyAsync(Guid companyId);
}