namespace Project.Core.Models.PositionHistory;

public class PositionHistoryPage
{
    public PositionHistoryPage(IReadOnlyList<PositionHistory> items, Page page)
    {
        Items = items;
        Page = page;
    }

    public IReadOnlyList<PositionHistory> Items { get; set; }
    public Page Page { get; set; }
}