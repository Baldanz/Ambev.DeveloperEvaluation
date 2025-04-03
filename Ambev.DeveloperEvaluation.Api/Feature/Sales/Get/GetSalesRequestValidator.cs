using FluentValidation;

namespace Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Sales.Get;

/// <summary>
/// Validator for GetSalesRequest
/// </summary>
public class GetSalesRequestValidator : AbstractValidator<GetSalesRequest>
{
    /// <summary>
    /// Initializes validation rules for GetSalesRequest
    /// </summary>
    public GetSalesRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}
