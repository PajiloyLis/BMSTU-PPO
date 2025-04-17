using Microsoft.Extensions.Logging;
using Project.Core.Exceptions;
using Project.Core.Models;
using Project.Core.Services;
using Project.Core.Repositories;

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

    public async Task<Company> AddCompanyAsync(Guid companyId, string title, DateOnly registrationDate, string phoneNumber,
        string email, string inn, string kpp, string ogrn, string address)
    {
        
    }
}
