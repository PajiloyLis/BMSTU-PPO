namespace Project.Core.Models;

public class EmployeePage
{
    public EmployeePage(List<Employee> employees, Page page)
    {
        Employees = employees;
        Page = page;
    }

    public EmployeePage()
    {
        Employees = new List<Employee>();
        Page = new Page();
    }

    public List<Employee> Employees { get; set; }

    public Page Page { get; set; }
}