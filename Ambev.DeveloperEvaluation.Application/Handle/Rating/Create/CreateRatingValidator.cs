using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.Rating.Create;

public class CreateRatingValidator : AbstractValidator<CreateRatingCommand>
{
    #region constructors

    public CreateRatingValidator() 
    {
        RuleFor(p => p.Rate).NotEmpty().WithMessage("Rate is mandatory");
        RuleFor(p => p.Count).NotEmpty().WithMessage("Count is mandatory");
    }

    #endregion
}
