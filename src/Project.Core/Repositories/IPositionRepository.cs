using Project.Core.Models;

namespace Project.Core.Repositories;

public interface IPositionRepository
{
    Task<Position> AddPositionAsync(CreatePosition position);
    Task<Position> GetPositionByIdAsync(Guid id);
    Task<Position> UpdatePositionAsync(UpdatePosition position);
    Task DeletePositionAsync(Guid id);
    Task<PositionPage> GetSubordinatesAsync(Guid parentId, int pageNumber, int pageSize);
}