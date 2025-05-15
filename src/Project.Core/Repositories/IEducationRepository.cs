using Project.Core.Models.Education;

namespace Project.Core.Repositories;

public interface IEducationRepository
{
    Task<Education> AddEducationAsync(CreateEducation education);
    Task<Education> GetEducationByIdAsync(Guid educationId);
    Task<Education> UpdateEducationAsync(UpdateEducation education);
    Task<EducationPage> GetEducationsAsync(Guid employeeId, int pageNumber, int pageSize);
    Task DeleteEducationAsync(Guid educationId);
}