using Project.Core.Models.Score;

namespace Project.Core.Services;

public interface IScoreService
{
    Task<Score> AddScoreAsync(CreateScore createScore);
    Task<Score> UpdateScoreAsync(UpdateScore updateScore);
    Task<Score> GetScoreAsync(Guid id);
    Task<ScorePage> GetScoresAsync(int pageNumber, int pageSize, DateTimeOffset? startDate, DateTimeOffset? endDate);

    Task<ScorePage> GetScoresByEmployeeAsync(Guid employeeId, int page, int pageSize, DateTimeOffset? startDate,
        DateTimeOffset? endDate);

    Task<ScorePage> GetScoresByAuthorAsync(Guid authorId, int page, int pageSize, DateTimeOffset? startDate,
        DateTimeOffset? endDate);

    Task<ScorePage> GetScoresSubordinatesByEmployeeAsync(Guid employeeId, int page, int pageSize,
        DateTimeOffset? startDate, DateTimeOffset? endDate);

    Task<ScorePage> GetScoresByPositionAsync(Guid positionId, int page, int pageSize, DateTimeOffset? startDate,
        DateTimeOffset? endDate);

    Task DeleteScoreAsync(Guid id);
}