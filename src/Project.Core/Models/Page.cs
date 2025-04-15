namespace Project.Core.Models;

public class Page
{
    public Page(int pageNumber, int totalPages, int totalItems)
    {
        PageNumber = pageNumber;
        TotalPages = totalPages;
        TotalItems = totalItems;
    }

    public Page()
    {
    }

    public int PageNumber { get; set; }

    public int TotalPages { get; set; }

    public int TotalItems { get; set; }

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;
}