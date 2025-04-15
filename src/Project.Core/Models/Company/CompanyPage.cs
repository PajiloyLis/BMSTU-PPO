namespace Project.Core.Models;

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

    public List<Company> Companies { get; set; }

    public Page Page { get; set; }
}