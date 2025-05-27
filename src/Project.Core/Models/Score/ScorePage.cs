namespace Project.Core.Models.Score;

public class ScorePage
{
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

    public IReadOnlyList<Score> Items { get; set; }
    public Page Page { get; set; }
}