using Project.Core.Models.Score;

namespace Project.Core.Repositories;

public interface IScoreRepository
{
    Task<Score> AddScoreAsync(CreateScore score);
    Task<Score> GetScoreByIdAsync(Guid id);
    Task<Score> UpdateScoreAsync(UpdateScore score);
    Task DeleteScoreAsync(Guid id);
    Task<ScorePage> GetScoresAsync(int pageNumber, int pageSize, DateTimeOffset? startDate, DateTimeOffset? endDate);

    Task<ScorePage> GetScoresByEmployeeIdAsync(Guid employeeId, int pageNumber, int pageSize, DateTimeOffset? startDate,
        DateTimeOffset? endDate);

    Task<ScorePage> GetScoresByPositionIdAsync(Guid positionId, int pageNumber, int pageSize, DateTimeOffset? startDate,
        DateTimeOffset? endDate);

    Task<ScorePage> GetScoresByAuthorIdAsync(Guid authorId, int pageNumber, int pageSize, DateTimeOffset? startDate,
        DateTimeOffset? endDate);

    Task<ScorePage> GetScoresSubordinatesByEmployeeIdAsync(Guid employeeId, int pageNumber, int pageSize,
        DateTimeOffset? startDate, DateTimeOffset? endDate);
}