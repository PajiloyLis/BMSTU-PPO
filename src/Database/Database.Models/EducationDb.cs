namespace Database.Models;

public class EducationDb
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string Institution { get; set; }
    public string Level { get; set; }
    public string StudyField { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }

    public EducationDb()
    {
        Institution = string.Empty;
        Level = string.Empty;
        StudyField = string.Empty;
    }

    public EducationDb(Guid id, Guid employeeId, string institution, string level, string studyField,
        DateOnly startDate, DateOnly? endDate)
    {
        if (string.IsNullOrWhiteSpace(institution))
            throw new ArgumentException("Institution cannot be empty");
        
        if (string.IsNullOrWhiteSpace(level))
            throw new ArgumentException("Level cannot be empty");
        
        if (string.IsNullOrWhiteSpace(studyField))
            throw new ArgumentException("StudyField cannot be empty");
        
        if (startDate > DateOnly.FromDateTime(DateTime.Today) || (endDate is not null && startDate > endDate))
            throw new ArgumentException("StartDate cannot be later than EndDate or later than today");
        
        if (endDate is not null && endDate > DateOnly.FromDateTime(DateTime.Today))
            throw new ArgumentException("EndDate cannot be later than today");

        Id = id;
        EmployeeId = employeeId;
        Institution = institution;
        Level = level;
        StudyField = studyField;
        StartDate = startDate;
        EndDate = endDate;
    }
}