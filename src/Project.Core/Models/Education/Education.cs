using Project.Core.Exceptions;

namespace Project.Core.Models.Education;

public class Education
{
    public Guid Id { get; }
    public Guid EmployeeId { get; }
    public string Institution { get; }
    public EducationLevel Level { get; }

    public Education(Guid id, Guid employeeId, string institution, string level, string studyField,
        DateOnly startDate, DateOnly? endDate)
    {
        if (!Guid.TryParse(id.ToString(), out _))
            throw new ArgumentException("Id cannot be empty");
        
        if (!Guid.TryParse(employeeId.ToString(), out _))
            throw new ArgumentException("EmployeeId cannot be empty");
        
        if (string.IsNullOrWhiteSpace(institution))
            throw new ArgumentException("Institution cannot be empty");
        
        if (string.IsNullOrWhiteSpace(studyField))
            throw new ArgumentException("StudyField cannot be empty");
        
        if (startDate > DateOnly.FromDateTime(DateTime.Today) || (endDate is not null && startDate > endDate))
            throw new ArgumentException("StartDate cannot be later than EndDate or later than today");

        if (endDate is not null && endDate > DateOnly.FromDateTime(DateTime.Today))
            throw new ArgumentException("EndDate cannot be later than today");
        
        Level = level.ToEducationLevel();
        Id = id;
        EmployeeId = employeeId;
        Institution = institution;
        StudyField = studyField;
        StartDate = startDate;
        EndDate = endDate;
    }
   
    public string StudyField { get; }

    public DateOnly StartDate { get; }

    public DateOnly? EndDate { get; }
}