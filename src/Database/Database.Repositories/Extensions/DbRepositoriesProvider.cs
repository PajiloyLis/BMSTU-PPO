using Microsoft.Extensions.DependencyInjection;
using Project.Core.Repositories;

namespace Database.Repositories.Extensions;

public static class DbRepositoriesProvider
{
    public static IServiceCollection AddDbRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        return services;
    }
}