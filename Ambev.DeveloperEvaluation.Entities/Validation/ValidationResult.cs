using FV = FluentValidation.Results;

namespace Ambev.DeveloperEvaluation.Entity.Validation;

public class ValidationResult
{
    #region constructors

    /// <summary>
    /// ValidationResult constructor
    /// </summary>
    public ValidationResult() { }

    /// <summary>
    /// ValidationResult constructor
    /// </summary>
    /// <param name="validationResult">fluent validation propertis for user data validation</param>
    public ValidationResult(FV.ValidationResult validationResult)
    {
        IsValid = validationResult.IsValid;
        Errors = validationResult.Errors.Select(o => (ValidationError)o);
    }

    #endregion

    #region properties
    public bool IsValid { get; set; }
    public IEnumerable<ValidationError> Errors { get; set; } = [];
    #endregion
}
