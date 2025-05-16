namespace Project.Core.Models;

public class PositionPage
{
    public PositionPage()
    {
        Positions = new List<Position>();
        Page = new Page();
    }

    public PositionPage(IReadOnlyList<Position> positions, Page page)
    {
        Positions = positions;
        Page = page;
    }

    public IReadOnlyList<Position> Positions { get; }
    public Page Page { get; }
}