using Microsoft.Extensions.Logging;
using Project.Core.Exceptions;
using Project.Core.Models.PostHistory;
using Project.Core.Repositories;
using Project.Core.Services;

namespace Project.Services.PostHistoryService;

public class PostHistoryService : IPostHistoryService
{
    private readonly ILogger<PostHistoryService> _logger;
    private readonly IPostHistoryRepository _repository;

    public PostHistoryService(
        IPostHistoryRepository repository,
        ILogger<PostHistoryService> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<PostHistory> AddPostHistoryAsync(
        Guid postId,
        Guid employeeId,
        DateOnly startDate,
        DateOnly? endDate = null)
    {
        try
        {
            var createPostHistory = new CreatePostHistory(postId, employeeId, startDate, endDate);
            return await _repository.AddPostHistoryAsync(createPostHistory);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding post history for employee {EmployeeId} and post {PostId}",
                employeeId, postId);
            throw;
        }
    }

    public async Task<PostHistory> GetPostHistoryAsync(Guid postId, Guid employeeId)
    {
        try
        {
            return await _repository.GetPostHistoryByIdAsync(postId, employeeId);
        }
        catch (PostHistoryNotFoundException)
        {
            _logger.LogWarning("Post history not found for employee {EmployeeId} and post {PostId}",
                employeeId, postId);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting post history for employee {EmployeeId} and post {PostId}",
                employeeId, postId);
            throw;
        }
    }

    public async Task<PostHistory> UpdatePostHistoryAsync(
        Guid postId,
        Guid employeeId,
        DateOnly? startDate = null,
        DateOnly? endDate = null)
    {
        try
        {
            var updatePostHistory = new UpdatePostHistory(postId, employeeId, startDate, endDate);
            return await _repository.UpdatePostHistoryAsync(updatePostHistory);
        }
        catch (PostHistoryNotFoundException)
        {
            _logger.LogWarning("Post history not found for employee {EmployeeId} and post {PostId}",
                employeeId, postId);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating post history for employee {EmployeeId} and post {PostId}",
                employeeId, postId);
            throw;
        }
    }

    public async Task DeletePostHistoryAsync(Guid postId, Guid employeeId)
    {
        try
        {
            await _repository.DeletePostHistoryAsync(postId, employeeId);
        }
        catch (PostHistoryNotFoundException)
        {
            _logger.LogWarning("Post history not found for employee {EmployeeId} and post {PostId}",
                employeeId, postId);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting post history for employee {EmployeeId} and post {PostId}",
                employeeId, postId);
            throw;
        }
    }

    public async Task<PostHistoryPage> GetPostHistoryByEmployeeAsync(
        Guid employeeId,
        int pageNumber,
        int pageSize,
        DateOnly startDate,
        DateOnly endDate)
    {
        try
        {
            return await _repository.GetPostHistoryByEmployeeIdAsync(
                employeeId,
                pageNumber,
                pageSize,
                startDate,
                endDate);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting post history for employee {EmployeeId}", employeeId);
            throw;
        }
    }

    public async Task<PostHistoryPage> GetSubordinatesPostHistoryAsync(
        Guid managerId,
        int pageNumber,
        int pageSize,
        DateOnly startDate,
        DateOnly endDate)
    {
        try
        {
            return await _repository.GetSubordinatesPostHistoryAsync(
                managerId,
                pageNumber,
                pageSize,
                startDate,
                endDate);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting subordinates post history for manager {ManagerId}", managerId);
            throw;
        }
    }
}