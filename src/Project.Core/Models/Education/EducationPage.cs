namespace Project.Core.Models;

public class EducationPage
{
    public EducationPage()
    {
        Educations = new List<Education>();
        Page = new Page(1, 0, 10);
    }

    public EducationPage(IReadOnlyList<Education> educations, Page page)
    {
        Educations = educations;
        Page = page;
    }

    public IReadOnlyList<Education> Educations { get; }
    public Page Page { get; }
}