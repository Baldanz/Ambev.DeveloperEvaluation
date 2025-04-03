using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.Cart.Create;

public class CreateCartValidator : AbstractValidator<CreateCartCommand>
{
    #region constructors

    public CreateCartValidator() 
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("User is mandatory");
    }

    #endregion
}
