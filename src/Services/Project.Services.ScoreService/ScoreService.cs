using Microsoft.Extensions.Logging;
using Project.Core.Models.Score;
using Project.Core.Repositories;
using Project.Core.Services;

namespace Project.Services.ScoreService;

public class ScoreService : IScoreService
{
    private readonly ILogger<ScoreService> _logger;
    private readonly IScoreRepository _repository;

    public ScoreService(IScoreRepository repository, ILogger<ScoreService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<BaseScore> AddScoreAsync(CreateScore createScore)
    {
        try
        {
            var result = await _repository.AddScoreAsync(createScore);
            _logger.LogInformation("Score for employee {EmployeeId} was added", result.EmployeeId);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while adding score");
            throw;
        }
    }

    public async Task<BaseScore> UpdateScoreAsync(UpdateScore updateScore)
    {
        try
        {
            var result = await _repository.UpdateScoreAsync(updateScore);
            _logger.LogInformation("Score with id {Id} was updated", updateScore.Id);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while updating score with id {Id}", updateScore.Id);
            throw;
        }
    }

    public async Task<BaseScore> GetScoreAsync(Guid id)
    {
        try
        {
            var result = await _repository.GetScoreByIdAsync(id);
            _logger.LogInformation("Score with id {Id} was retrieved", id);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while getting score with id {Id}", id);
            throw;
        }
    }

    public async Task<ScorePage> GetScoresAsync(int pageNumber, int pageSize, DateTimeOffset? startDate,
        DateTimeOffset? endDate)
    {
        try
        {
            var result = await _repository.GetScoresAsync(pageNumber, pageSize, startDate, endDate);
            _logger.LogInformation("Scores were retrieved with pagination");
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while getting scores with pagination");
            throw;
        }
    }

    public async Task<ScorePage> GetScoresByEmployeeAsync(Guid employeeId, int page, int pageSize,
        DateTimeOffset? startDate, DateTimeOffset? endDate)
    {
        try
        {
            var result = await _repository.GetScoresByEmployeeIdAsync(employeeId, page, pageSize, startDate, endDate);
            _logger.LogInformation("Scores for employee {EmployeeId} were retrieved", employeeId);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while getting scores for employee {EmployeeId}", employeeId);
            throw;
        }
    }

    public async Task<ScorePage> GetScoresByAuthorAsync(Guid authorId, int page, int pageSize,
        DateTimeOffset? startDate, DateTimeOffset? endDate)
    {
        try
        {
            var result = await _repository.GetScoresByAuthorIdAsync(authorId, page, pageSize, startDate, endDate);
            _logger.LogInformation("Scores by author {AuthorId} were retrieved", authorId);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while getting scores by author {AuthorId}", authorId);
            throw;
        }
    }

    public async Task<ScorePage> GetScoresSubordinatesByEmployeeAsync(Guid employeeId, int page, int pageSize,
        DateTimeOffset? startDate, DateTimeOffset? endDate)
    {
        try
        {
            var result =
                await _repository.GetScoresSubordinatesByEmployeeIdAsync(employeeId, page, pageSize, startDate,
                    endDate);
            _logger.LogInformation("Subordinates scores for employee {EmployeeId} were retrieved", employeeId);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while getting subordinates scores for employee {EmployeeId}",
                employeeId);
            throw;
        }
    }

    public async Task<ScorePage> GetScoresByPositionAsync(Guid positionId, int page, int pageSize,
        DateTimeOffset? startDate, DateTimeOffset? endDate)
    {
        try
        {
            var result = await _repository.GetScoresByPositionIdAsync(positionId, page, pageSize, startDate, endDate);
            _logger.LogInformation("Scores for position {PositionId} were retrieved", positionId);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while getting scores for position {PositionId}", positionId);
            throw;
        }
    }

    public async Task DeleteScoreAsync(Guid id)
    {
        try
        {
            await _repository.DeleteScoreAsync(id);
            _logger.LogInformation("Score with id {Id} was deleted", id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while deleting score with id {Id}", id);
            throw;
        }
    }
}