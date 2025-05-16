namespace Project.Core.Models.Score;

public class UpdateScore
{
    public Guid Id { get; }
    public DateTimeOffset? CreatedAt { get; }
    public int? EfficiencyScore { get; }
    public int? EngagementScore { get; }
    public int? CompetencyScore { get; }

    public UpdateScore(Guid id, DateTimeOffset? createdAt = null, int? efficiencyScore = null, 
        int? engagementScore = null, int? competencyScore = null)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id cannot be empty", nameof(id));

        if (createdAt.HasValue && createdAt.Value > DateTimeOffset.UtcNow)
            throw new ArgumentException("CreatedAt cannot be in the future", nameof(createdAt));

        if (efficiencyScore.HasValue && (efficiencyScore.Value < 1 || efficiencyScore.Value > 5))
            throw new ArgumentException("EfficiencyScore must be between 1 and 5", nameof(efficiencyScore));
        
        if (engagementScore.HasValue && (engagementScore.Value < 1 || engagementScore.Value > 5))
            throw new ArgumentException("EngagementScore must be between 1 and 5", nameof(engagementScore));
        
        if (competencyScore.HasValue && (competencyScore.Value < 1 || competencyScore.Value > 5))
            throw new ArgumentException("CompetencyScore must be between 1 and 5", nameof(competencyScore));

        Id = id;
        CreatedAt = createdAt;
        EfficiencyScore = efficiencyScore;
        EngagementScore = engagementScore;
        CompetencyScore = competencyScore;
    }
} 