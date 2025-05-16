using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models;

public class PositionDb
{
    public PositionDb()
    {
    }

    public PositionDb(Guid id, Guid? parentId, string title, Guid companyId)
    {
        if (!Guid.TryParse(id.ToString(), out _))
            throw new ArgumentException("Invalid Id format", nameof(id));
        if (parentId.HasValue && !Guid.TryParse(parentId.Value.ToString(), out _))
            throw new ArgumentException("Invalid ParentId format", nameof(parentId));
        if (!Guid.TryParse(companyId.ToString(), out _))
            throw new ArgumentException("Invalid CompanyId format", nameof(companyId));
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty", nameof(title));

        Id = id;
        ParentId = parentId;
        Title = title;
        CompanyId = companyId;
    }

    [Key] public Guid Id { get; set; }

    public Guid? ParentId { get; set; }

    [Required] public string Title { get; set; } = null!;

    [Required] public Guid CompanyId { get; set; }

    // Навигационные свойства
    [ForeignKey(nameof(ParentId))] public PositionDb? Parent { get; set; }

    public ICollection<PositionDb> Children { get; set; } = new List<PositionDb>();

    [ForeignKey(nameof(CompanyId))] public CompanyDb Company { get; set; } = null;
}