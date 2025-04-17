using System.Text.Json.Serialization;

namespace Project.Dto.Http;

public class EmployeeDto
{
    public EmployeeDto(Guid employeeId,
        string fullName,
        string? phoneNumber,
        string email,
        DateOnly birthday,
        string? photoPath,
        string? duties
    )
    {
        EmployeeId = employeeId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
        Birthday = birthday;
        PhotoPath = photoPath;
        Duties = duties;
    }

    [JsonRequired]
    [JsonPropertyName("employeeId")]
    public Guid EmployeeId { get; set; }

    [JsonRequired]
    [JsonPropertyName("fullName")]
    public string FullName { get; set; }

    [JsonRequired]
    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    [JsonRequired]
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonRequired]
    [JsonPropertyName("birthday")]
    public DateOnly Birthday { get; set; }

    [JsonRequired]
    [JsonPropertyName("photoPath")]
    public string? PhotoPath { get; set; }

    [JsonRequired]
    [JsonPropertyName("duties")]
    public string? Duties { get; set; }
}