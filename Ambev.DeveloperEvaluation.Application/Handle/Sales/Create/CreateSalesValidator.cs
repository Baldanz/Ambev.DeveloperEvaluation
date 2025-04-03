using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.Sales.Create;

public class CreateSalesValidator : AbstractValidator<CreateSalesCommand>
{
    #region constructors

    public CreateSalesValidator() 
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("User is mandatory");
    }

    #endregion
}
