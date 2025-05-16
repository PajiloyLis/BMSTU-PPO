using Project.Core.Models;

namespace Project.Core.Services;

public interface IPostService
{
    /// <summary>
    /// Создает новую должность
    /// </summary>
    /// <param name="title">Название должности</param>
    /// <param name="salary">Зарплата</param>
    /// <param name="companyId">ID компании</param>
    /// <returns>Созданная должность</returns>
    Task<Post> AddPostAsync(string title, decimal salary, Guid companyId);

    /// <summary>
    /// Получает должность по ID
    /// </summary>
    /// <param name="postId">ID должности</param>
    /// <returns>Должность</returns>
    Task<Post> GetPostByIdAsync(Guid postId);

    /// <summary>
    /// Обновляет существующую должность
    /// </summary>
    /// <param name="postId">ID должности</param>
    /// <param name="companyId">ID компании</param>
    /// <param name="title">Новое название должности</param>
    /// <param name="salary">Новая зарплата</param>
    /// <returns>Обновленная должность</returns>
    Task<Post> UpdatePostAsync(Guid postId, Guid companyId, string? title = null, decimal? salary = null);

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