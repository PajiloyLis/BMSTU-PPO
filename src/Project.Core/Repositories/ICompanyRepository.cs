using Project.Core.Models;

namespace Project.Core.Repositories;

/// <summary>
/// Company repository
/// </summary>
public interface ICompanyRepository
{
    /// <summary>
    /// Asynchronous company addition method
    /// </summary>
    /// <param name="newCompany"><see cref="Project.Core.Models.CreationCompany"/>> model to add</param>
    /// <exception cref="Project.Core.Exceptions.CompanyAlreadyExistsException">
    /// If company with one of unique parameters
    /// already exists
    /// </exception>
    /// <returns><see cref="Project.Core.Models.Company"/> model representing added company entity</returns>
    public Task<Company> AddCompanyAsync(CreationCompany newCompany);

    /// <summary>
    /// Asynchronous search company by
    /// </summary>
    /// <param name="companyId"></param>
    /// <returns></returns>
    public Task<Company> GetCompanyByIdAsync(Guid companyId);

    public Task<Company> UpdateCompanyAsync(UpdateCompany company);

    public Task<CompanyPage> GetCompaniesAsync(int pageNumber, int pageSize);

    public Task DeleteCompanyAsync(Guid companyId);
}