namespace Dotnetstore.Shared.Common;

public class ErrorDto
{
    public bool Success { get; set; } = true;

    public string? ErrorMessage { get; set; }

    public string? StackTrace { get; set; }
}