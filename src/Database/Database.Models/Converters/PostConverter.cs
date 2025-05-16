using System.Diagnostics.CodeAnalysis;
using Project.Core.Models;

namespace Database.Models.Converters;

public static class PostConverter
{
    [return: NotNullIfNotNull(nameof(post))]
    public static PostDb? Convert(CreatePost? post)
    {
        if (post == null)
            return null;

        return new PostDb(Guid.NewGuid(),
            post.Title,
            post.Salary,
            post.CompanyId
        );
    }

    [return: NotNullIfNotNull(nameof(post))]
    public static PostDb? Convert(Post? post)
    {
        if (post == null)
            return null;

        return new PostDb(post.Id,
            post.Title,
            post.Salary,
            post.CompanyId);
    }

    [return: NotNullIfNotNull(nameof(post))]
    public static Post? Convert(PostDb? post)
    {
        if (post == null)
            return null;

        return new Post(post.Id,
            post.Title,
            post.Salary,
            post.CompanyId);
    }
}