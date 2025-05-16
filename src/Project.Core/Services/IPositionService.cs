using Project.Core.Models;

namespace Project.Core.Services;

public interface IPositionService
{
    Task<Position> AddPositionAsync(Guid parentId, string title, Guid companyId);
    Task<Position> GetPositionByIdAsync(Guid id);
    Task<Position> UpdatePositionAsync(Guid id, Guid companyId, Guid? parentId = null, string? title = null);
    Task DeletePositionAsync(Guid id);
    Task<PositionPage> GetSubordinatesAsync(Guid parentId, int pageNumber, int pageSize);
}