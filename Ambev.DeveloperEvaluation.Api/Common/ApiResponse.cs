using Ambev.DeveloperEvaluation.Entity.Validation;

namespace Ambev.DeveloperEvaluation.Api.Common;

public class ApiResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public IEnumerable<ValidationError> Errors { get; set; } = [];
}
