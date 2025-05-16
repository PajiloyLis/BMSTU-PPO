namespace Project.Core.Models;

public class CreateEducation
{
    public CreateEducation(Guid employeeId, string institution, string level, string studyField,
        DateOnly startDate, DateOnly? endDate = null)
    {
        if (!Guid.TryParse(employeeId.ToString(), out _))
            throw new ArgumentException("EmployeeId is invalid", nameof(employeeId));

        if (string.IsNullOrWhiteSpace(institution))
            throw new ArgumentException("Institution is invalid", nameof(institution));

        if (string.IsNullOrWhiteSpace(studyField))
            throw new ArgumentException("StudyField is invalid", nameof(studyField));

        if (startDate > DateOnly.FromDateTime(DateTime.Today) || (endDate is not null && startDate > endDate))
            throw new ArgumentException("StartDate is invalid", nameof(startDate));

        if (endDate is not null && endDate > DateOnly.FromDateTime(DateTime.Today))
            throw new ArgumentException("EndDate is invalid", nameof(endDate));

        Level = level.ToEducationLevel();

        EmployeeId = employeeId;
        Institution = institution;
        StudyField = studyField;
        StartDate = startDate;
        EndDate = endDate;
    }

    public Guid EmployeeId { get; }
    public string Institution { get; }
    public EducationLevel Level { get; }
    public string StudyField { get; }
    public DateOnly StartDate { get; }
    public DateOnly? EndDate { get; }
}