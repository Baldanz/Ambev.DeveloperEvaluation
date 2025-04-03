using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.Sales.Get;

public class GetSalesValidator : AbstractValidator<GetSalesCommand>
{
    /// <summary>
    /// Initializes validation rules for GetSalesCommand
    /// </summary>
    public GetSalesValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sales ID is required");
    }
}
