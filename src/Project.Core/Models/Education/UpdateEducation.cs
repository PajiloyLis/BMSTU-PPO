namespace Project.Core.Models.Education;

public class UpdateEducation
{
    public UpdateEducation(Guid id, Guid employeeId, string? institution = null, string? level = null,
        string? studyField = null,
        DateOnly? startDate = null, DateOnly? endDate = null)
    {
        if (!Guid.TryParse(id.ToString(), out _))
            throw new ArgumentException("Id cannot be empty");

        if (!Guid.TryParse(employeeId.ToString(), out _))
            throw new ArgumentException("EmployeeId cannot be empty");

        if (startDate is not null && endDate is not null && startDate > endDate)
            throw new ArgumentException("StartDate cannot be later than EndDate");

        if (startDate is not null && startDate > DateOnly.FromDateTime(DateTime.Today))
            throw new ArgumentException("StartDate cannot be later than today");

        if (endDate is not null && endDate > DateOnly.FromDateTime(DateTime.Today))
            throw new ArgumentException("EndDate cannot be later than today");

        if (level is not null)
            Level = level.ToEducationLevel();
        else
            Level = null;

        Id = id;
        EmployeeId = employeeId;
        Institution = institution;
        StudyField = studyField;
        StartDate = startDate;
        EndDate = endDate;
    }

    public Guid Id { get; }
    public Guid EmployeeId { get; }
    public string? Institution { get; }
    public EducationLevel? Level { get; }
    public string? StudyField { get; }
    public DateOnly? StartDate { get; }
    public DateOnly? EndDate { get; }
}