namespace Project.Core.Models;

public class PostPage
{
    public PostPage()
    {
        Posts = new List<Post>();
        Page = new Page();
    }

    public PostPage(IReadOnlyList<Post> posts, Page page)
    {
        Posts = posts;
        Page = page;
    }

    public IReadOnlyList<Post> Posts { get; set; }
    public Page Page { get; set; }
}