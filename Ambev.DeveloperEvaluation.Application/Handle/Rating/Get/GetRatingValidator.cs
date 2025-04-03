using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.Rating.Get;

public class GetRatingValidator : AbstractValidator<GetRatingCommand>
{
    /// <summary>
    /// Initializes validation rules for GetRatingCommand
    /// </summary>
    public GetRatingValidator()
    {
        RuleFor(x => x.Id == null && x.ProductId == null)
            .NotNull().WithMessage("Rating or Product are both mandatory");
    }
}
