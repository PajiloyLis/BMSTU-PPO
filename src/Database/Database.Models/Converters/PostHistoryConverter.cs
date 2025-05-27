using System.Diagnostics.CodeAnalysis;
using Project.Core.Models.PostHistory;

namespace Database.Models.Converters;

public static class PostHistoryConverter
{
    [return: NotNullIfNotNull(nameof(postHistory))]
    public static PostHistoryDb? Convert(CreatePostHistory? postHistory)
    {
        if (postHistory == null)
            return null;

        return new PostHistoryDb(
            postHistory.PostId,
            postHistory.EmployeeId,
            postHistory.StartDate,
            postHistory.EndDate);
    }

    [return: NotNullIfNotNull(nameof(postHistory))]
    public static PostHistoryDb? Convert(PostHistory? postHistory)
    {
        if (postHistory == null)
            return null;

        return new PostHistoryDb(
            postHistory.PostId,
            postHistory.EmployeeId,
            postHistory.StartDate,
            postHistory.EndDate);
    }

    [return: NotNullIfNotNull(nameof(postHistory))]
    public static PostHistory? Convert(PostHistoryDb? postHistory)
    {
        if (postHistory == null)
            return null;

        return new PostHistory(
            postHistory.PostId,
            postHistory.EmployeeId,
            postHistory.StartDate,
            postHistory.EndDate);
    }
}