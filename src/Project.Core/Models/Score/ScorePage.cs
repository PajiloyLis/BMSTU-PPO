namespace Project.Core.Models.Score;

public class ScorePage
{
    public IReadOnlyList<Score> Items { get; }
    public Page Page { get; }

    public ScorePage()
    {
        Items = new List<Score>();
        Page = new Page();
    }

    public ScorePage(IReadOnlyList<Score> items, Page page)
    {
        Items = items;
        Page = page;
    }
} 