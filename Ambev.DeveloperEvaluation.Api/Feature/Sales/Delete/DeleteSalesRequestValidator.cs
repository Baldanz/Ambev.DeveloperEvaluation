using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSales;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Delete;

/// <summary>
/// Validator for DeleteSalesRequest
/// </summary>
public class DeleteSalesRequestValidator : AbstractValidator<DeleteSalesRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteSalesRequest
    /// </summary>
    public DeleteSalesRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}
