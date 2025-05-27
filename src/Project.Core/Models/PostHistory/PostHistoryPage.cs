namespace Project.Core.Models.PostHistory;

public class PostHistoryPage
{
    public PostHistoryPage(IReadOnlyList<PostHistory> items, Page page)
    {
        Items = items;
        Page = page;
    }

    public IReadOnlyList<PostHistory> Items { get; set; }
    public Page Page { get; set; }
}