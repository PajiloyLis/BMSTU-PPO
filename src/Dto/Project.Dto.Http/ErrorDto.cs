using System.Text.Json.Serialization;

namespace Project.Dto.Http;

public class ErrorDto
{
    public ErrorDto(string errorType, string message)
    {
        ErrorType = errorType;
        Message = message;
    }

    [JsonRequired]
    [JsonPropertyName("errorType")]
    public string ErrorType { get; set; }

    [JsonRequired]
    [JsonPropertyName("message")]
    public string Message { get; set; }
}