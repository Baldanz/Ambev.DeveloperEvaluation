using FluentValidation;

namespace Ambev.DeveloperEvaluation.Api.Feature.Product.Create;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(p => p.Title).NotEmpty().WithMessage("Product Title is mandatory");
        RuleFor(p => p.Description).NotEmpty().WithMessage("Product Description is mandatory");
        RuleFor(p => p.Category).NotEmpty().WithMessage("Product Category is mandatory");
        RuleFor(p => p.Price).PrecisionScale(5, 2, true).WithMessage("Product Price cannot be greater than 5 and must be a precison of 2");
    }
}