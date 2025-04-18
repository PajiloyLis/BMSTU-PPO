namespace Project.Core.Models;

/// <summary>
/// Companies page model
/// </summary>
public class CompanyPage
{
    public CompanyPage(List<Company> companies, Page page)
    {
        Companies = companies;
        Page = page;
    }

    public CompanyPage()
    {
        Companies = new List<Company>();
        Page = new Page();
    }

    /// <summary>
    /// Companies on the page
    /// </summary>
    public List<Company> Companies { get; set; }

    /// <summary>
    /// Page model
    /// </summary>
    public Page Page { get; set; }
}