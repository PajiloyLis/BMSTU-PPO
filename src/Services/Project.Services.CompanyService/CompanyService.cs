using Microsoft.Extensions.Logging;
using Project.Core.Exceptions;
using Project.Core.Models;
using Project.Core.Repositories;
using Project.Core.Services;

namespace Project.Services.CompanyService;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ILogger<CompanyService> _logger;

    public CompanyService(ICompanyRepository companyRepository, ILogger<CompanyService> logger)
    {
        _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Company> AddCompanyAsync(string title, DateOnly registrationDate, string phoneNumber,
        string email, string inn, string kpp, string ogrn, string address)
    {
        try
        {
            var createdCompany = await _companyRepository.AddCompanyAsync(new CreationCompany(title, registrationDate,
                phoneNumber, email, inn, kpp, ogrn, address));

            return createdCompany;
        }
        catch (CompanyAlreadyExistsException e)
        {
            _logger.LogWarning(e,
                $"Company with title - {title}, or phone - {phoneNumber}, or email - {email}, or inn - {inn}, or kpp - {kpp}, or ogrn - {ogrn} already exists");
            throw;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error creating company - {title}");
            throw;
        }
    }

    public async Task<Company> GetCompanyByIdAsync(Guid companyId)
    {
        try
        {
            var company = await _companyRepository.GetCompanyByIdAsync(companyId);

            return company;
        }
        catch (CompanyNotFoundException e)
        {
            _logger.LogWarning(e, $"Company with id - {companyId} not found");
            throw;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error getting company with id - {companyId}");
            throw;
        }
    }

    public async Task<Company> UpdateCompanyAsync(Guid companyId, string? title, DateOnly? registrationDate,
        string? phoneNumber, string? email, string? inn,
        string? kpp, string? ogrn, string? address)
    {
        try
        {
            var company = await _companyRepository.UpdateCompanyAsync(new UpdateCompany(companyId, title,
                registrationDate, phoneNumber, email, inn, kpp, ogrn, address));

            return company;
        }
        catch (CompanyAlreadyExistsException e)
        {
            _logger.LogWarning(e, "Company with such parameters already exists");
            throw;
        }
        catch (CompanyNotFoundException e)
        {
            _logger.LogWarning(e, $"Company with id - {companyId} not found");
            throw;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error updating company with id {companyId}");
            throw;
        }
    }

    public async Task<CompanyPage> GetCompaniesAsync(int pageNumber, int pageSize)
    {
        try
        {
            var companies = await _companyRepository.GetCompaniesAsync(pageNumber, pageSize);

            return companies;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting companies");
            throw;
        }
    }

    public async Task DeleteCompanyAsync(Guid companyId)
    {
        try
        {
            await _companyRepository.DeleteCompanyAsync(companyId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error deleting company with id - {companyId}");
            throw;
        }
    }
}