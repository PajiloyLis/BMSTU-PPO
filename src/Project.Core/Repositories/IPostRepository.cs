using Project.Core.Models;

namespace Project.Core.Repositories;

public interface IPostRepository
{
    /// <summary>
    /// Добавляет новую должность
    /// </summary>
    /// <param name="post">Должность для добавления</param>
    /// <returns>Добавленная должность</returns>
    Task<Post> AddPostAsync(CreatePost post);

    /// <summary>
    /// Получает должность по ID
    /// </summary>
    /// <param name="postId">ID должности</param>
    /// <returns>Должность</returns>
    Task<Post> GetPostByIdAsync(Guid postId);

    /// <summary>
    /// Обновляет существующую должность
    /// </summary>
    /// <param name="post">Должность для обновления</param>
    /// <returns>Обновленная должность</returns>
    Task<Post> UpdatePostAsync(UpdatePost post);

    /// <summary>
    /// Получает список должностей с пагинацией
    /// </summary>
    /// <param name="companyId">ID компании</param>
    /// <param name="pageNumber">Номер страницы</param>
    /// <param name="pageSize">Размер страницы</param>
    /// <returns>Страница с должностями</returns>
    Task<PostPage> GetPostsAsync(Guid companyId, int pageNumber, int pageSize);

    /// <summary>
    /// Удаляет должность
    /// </summary>
    /// <param name="postId">ID должности</param>
    Task DeletePostAsync(Guid postId);
}