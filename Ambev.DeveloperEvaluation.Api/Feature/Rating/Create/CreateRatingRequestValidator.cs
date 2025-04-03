using FluentValidation;

namespace Ambev.DeveloperEvaluation.Api.Feature.Rating.Create;

public class CreateRatingRequestValidator : AbstractValidator<CreateRatingRequest>
{
    public CreateRatingRequestValidator()
    {
        RuleFor(p => p.Title).NotEmpty().WithMessage("Rating Title is mandatory");
        RuleFor(p => p.Description).NotEmpty().WithMessage("Rating Description is mandatory");
        RuleFor(p => p.Category).NotEmpty().WithMessage("Rating Category is mandatory");
        RuleFor(p => p.Price).PrecisionScale(5, 2, true).WithMessage("Rating Price cannot be greater than 5 and must be a precison of 2");
    }
}