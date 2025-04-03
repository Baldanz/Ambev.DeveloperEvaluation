using Ambev.DeveloperEvaluation.Entity.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Cart.Create;

public class CreateCartCommand : IRequest<CreateCartResult>
{
    #region properties

    public Guid UserId { get; set; }

    #endregion

    #region methods

    public ValidationResult Validate()
    {
        var validator = new CreateCartValidator();
        var result = validator.Validate(this);
        return new ValidationResult
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationError)o)
        };
    }

    #endregion
}