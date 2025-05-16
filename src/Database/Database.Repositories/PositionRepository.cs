using Database.Context;
using Database.Models.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.Core.Exceptions;
using Project.Core.Models;
using Project.Core.Repositories;

namespace Database.Repositories;

public class PositionRepository : IPositionRepository
{
    private readonly ProjectDbContext _context;
    private readonly ILogger<PositionRepository> _logger;

    public PositionRepository(ProjectDbContext context, ILogger<PositionRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Position> AddPositionAsync(CreatePosition position)
    {
        try
        {
            var positionDb = PositionConverter.Convert(position);
            if (positionDb is null)
            {
                _logger.LogWarning("Failed to convert CreatePosition to PositionDb");
                throw new ArgumentException("Failed to convert CreatePosition to PositionDb");
            }

            var existingPosition = await _context.PositionDb
                .FirstOrDefaultAsync(p => p.CompanyId == position.CompanyId && p.Title == position.Title);

            if (existingPosition is not null)
            {
                _logger.LogWarning("Position with title {Title} already exists in company {CompanyId}", position.Title,
                    position.CompanyId);
                throw new PositionAlreadyExistException(
                    $"Position with title {position.Title} already exists in company {position.CompanyId}");
            }

            await _context.PositionDb.AddAsync(positionDb);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Position with id {Id} was added", positionDb.Id);
            return PositionConverter.Convert(positionDb)!;
        }
        catch (Exception e) when (e is not PositionAlreadyExistException)
        {
            _logger.LogError(e, "Error occurred while adding position");
            throw;
        }
    }

    public async Task<Position> GetPositionByIdAsync(Guid id)
    {
        try
        {
            var position = await _context.PositionDb
                .FirstOrDefaultAsync(p => p.Id == id);

            if (position is null)
            {
                _logger.LogWarning("Position with id {Id} not found", id);
                throw new PositionNotFoundException($"Position with id {id} not found");
            }

            _logger.LogInformation("Position with id {Id} was retrieved", id);
            return PositionConverter.Convert(position)!;
        }
        catch (Exception e) when (e is not PositionNotFoundException)
        {
            _logger.LogError(e, "Error occurred while getting position with id {Id}", id);
            throw;
        }
    }

    public async Task<Position> UpdatePositionAsync(UpdatePosition position)
    {
        try
        {
            var positionDb = await _context.PositionDb
                .FirstOrDefaultAsync(p => p.Id == position.Id && p.CompanyId == position.CompanyId);

            if (positionDb is null)
            {
                _logger.LogWarning("Position with id {Id} not found for update", position.Id);
                throw new PositionNotFoundException($"Position with id {position.Id} not found");
            }

            var existingPosition = await _context.PositionDb
                .Where(p => p.Id != position.Id &&
                            p.CompanyId == position.CompanyId &&
                            p.Title == position.Title)
                .FirstOrDefaultAsync();

            if (existingPosition is not null)
            {
                _logger.LogWarning("Position with title {Title} already exists in company {CompanyId}", position.Title,
                    position.CompanyId);
                throw new PositionAlreadyExistException(
                    $"Position with title {position.Title} already exists in company {position.CompanyId}");
            }

            positionDb.Title = position.Title ?? positionDb.Title;
            positionDb.ParentId = position.ParentId ?? positionDb.ParentId;
            await _context.SaveChangesAsync();

            _logger.LogInformation("Position with id {Id} was updated", position.Id);
            return PositionConverter.Convert(positionDb)!;
        }
        catch (Exception e) when (e is not PositionNotFoundException and not PositionAlreadyExistException)
        {
            _logger.LogError(e, "Error occurred while updating position with id {Id}", position.Id);
            throw;
        }
    }

    public async Task DeletePositionAsync(Guid id)
    {
        try
        {
            var position = await _context.PositionDb
                .FirstOrDefaultAsync(p => p.Id == id);

            if (position is null)
            {
                _logger.LogWarning("Position with id {Id} not found for deletion", id);
                throw new PositionNotFoundException($"Position with id {id} not found");
            }

            _context.PositionDb.Remove(position);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Position with id {Id} was deleted", id);
        }
        catch (Exception e) when (e is not PositionNotFoundException)
        {
            _logger.LogError(e, "Error occurred while deleting position with id {Id}", id);
            throw;
        }
    }

    public async Task<PositionPage> GetSubordinatesAsync(Guid parentId, int pageNumber, int pageSize)
    {
        try
        {
            var positions = await _context.PositionDb
                .Where(p => p.ParentId == parentId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalItems = await _context.PositionDb
                .CountAsync(p => p.ParentId == parentId);

            var page = new Page(pageNumber, totalItems, pageSize);
            var result = new PositionPage(positions.Select(p => PositionConverter.Convert(p)!).ToList(), page);

            _logger.LogInformation("Subordinates for position {ParentId} were retrieved", parentId);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while getting subordinates for position {ParentId}", parentId);
            throw;
        }
    }
}