using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.Sales.Delete;

/// <summary>
/// Validator for DeleteSalesCommand
/// </summary>
public class DeleteSalesValidator : AbstractValidator<DeleteSalesCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteSalesCommand
    /// </summary>
    public DeleteSalesValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}
