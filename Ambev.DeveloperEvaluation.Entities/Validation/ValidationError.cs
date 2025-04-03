using FluentValidation.Results;

namespace Ambev.DeveloperEvaluation.Entity.Validation;

public class ValidationError
{
    #region properties

    public string Id { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;

    #endregion

    #region constructors

    public static explicit operator ValidationError(ValidationFailure validationFailure)
    {
        return new ValidationError
        {
            Message = validationFailure.ErrorMessage,
            Id = validationFailure.ErrorCode
        };
    }

    #endregion
}
