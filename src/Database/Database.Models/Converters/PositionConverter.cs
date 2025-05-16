using System.Diagnostics.CodeAnalysis;
using Project.Core.Models;

namespace Database.Models.Converters;

public static class PositionConverter
{
    [return: NotNullIfNotNull("position")]
    public static PositionDb? Convert(CreatePosition? position)
    {
        if (position is null)
            return null;

        return new PositionDb(
            Guid.NewGuid(),
            position.ParentId,
            position.Title,
            position.CompanyId
        );
    }

    [return: NotNullIfNotNull("position")]
    public static PositionDb? Convert(Position? position)
    {
        if (position is null)
            return null;

        return new PositionDb(
            position.Id,
            position.ParentId,
            position.Title,
            position.CompanyId
        );
    }

    [return: NotNullIfNotNull("position")]
    public static Position? Convert(PositionDb? position)
    {
        if (position is null)
            return null;

        return new Position(
            position.Id,
            position.ParentId ?? Guid.Empty,
            position.Title,
            position.CompanyId
        );
    }
}