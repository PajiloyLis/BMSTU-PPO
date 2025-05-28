using Microsoft.Extensions.Logging;
using Project.Core.Models;
using Project.Core.Models.Position;
using Project.Core.Models.PositionHistory;
using Project.Core.Repositories;
using Project.Core.Services;

namespace Project.Services.PositionService;

public class PositionService : IPositionService
{
    private readonly ILogger<PositionService> _logger;
    private readonly IPositionRepository _repository;

    public PositionService(IPositionRepository repository, ILogger<PositionService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<BasePosition> AddPositionAsync(Guid parentId, string title, Guid companyId)
    {
        try
        {
            var model = new CreatePosition(parentId, title, companyId);
            var result = await _repository.AddPositionAsync(model);
            _logger.LogInformation("Position added: {Id}", result.Id);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding position");
            throw;
        }
    }

    public async Task<BasePosition> GetPositionByIdAsync(Guid id)
    {
        try
        {
            var result = await _repository.GetPositionByIdAsync(id);
            _logger.LogInformation("Position retrieved: {Id}", id);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting position by id {Id}", id);
            throw;
        }
    }

    public async Task<BasePosition> UpdatePositionAsync(Guid id, Guid companyId, Guid? parentId = null,
        string? title = null)
    {
        try
        {
            var model = new UpdatePosition(id, companyId, parentId, title);
            var result = await _repository.UpdatePositionAsync(model);
            _logger.LogInformation("Position updated: {Id}", id);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating position {Id}", id);
            throw;
        }
    }

    public async Task DeletePositionAsync(Guid id)
    {
        try
        {
            await _repository.DeletePositionAsync(id);
            _logger.LogInformation("Position deleted: {Id}", id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting position {Id}", id);
            throw;
        }
    }

    public async Task<PositionHierarchyPage> GetSubordinatesAsync(Guid parentId, int pageNumber, int pageSize)
    {
        try
        {
            var result = await _repository.GetSubordinatesAsync(parentId, pageNumber, pageSize);
            _logger.LogInformation("Subordinates retrieved for parentId: {ParentId}", parentId);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting subordinates for parentId {ParentId}", parentId);
            throw;
        }
    }
}