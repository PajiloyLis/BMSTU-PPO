using System.Diagnostics.CodeAnalysis;
using Project.Core.Models.PositionHistory;

namespace Project.Database.Models.Converters;

public static class PositionHistoryConverter
{
    [return: NotNullIfNotNull("positionHistory")]
    public static PositionHistoryDb? Convert(CreatePositionHistory? positionHistory)
    {
        if (positionHistory == null)
            return null;

        return new PositionHistoryDb(
            positionHistory.PositionId,
            positionHistory.EmployeeId,
            positionHistory.StartDate,
            positionHistory.EndDate);
    }

    [return: NotNullIfNotNull("positionHistory")]
    public static PositionHistoryDb? Convert(PositionHistory? positionHistory)
    {
        if (positionHistory == null)
            return null;

        return new PositionHistoryDb(
            positionHistory.PositionId,
            positionHistory.EmployeeId,
            positionHistory.StartDate,
            positionHistory.EndDate);
    }

    [return: NotNullIfNotNull("positionHistoryDb")]
    public static PositionHistory? Convert(PositionHistoryDb? positionHistoryDb)
    {
        if (positionHistoryDb == null)
            return null;

        return new PositionHistory(
            positionHistoryDb.PositionId,
            positionHistoryDb.EmployeeId,
            positionHistoryDb.StartDate,
            positionHistoryDb.EndDate);
    }
}