using Project.Core.Models;

namespace Project.Core.Services;

public interface IEducationService
{
    Task<Education> AddEducationAsync(Guid employeeId, string institution, string level, string studyField,
        DateOnly startDate, DateOnly? endDate = null);

    Task<Education> GetEducationByIdAsync(Guid educationId);

    Task<Education> UpdateEducationAsync(Guid educationId, Guid employeeId, string? institution = null,
        string? level = null, string? studyField = null, DateOnly? startDate = null, DateOnly? endDate = null);

    Task<EducationPage> GetEducationsAsync(Guid employeeId, int pageNumber, int pageSize);

    Task DeleteEducationAsync(Guid educationId);
}