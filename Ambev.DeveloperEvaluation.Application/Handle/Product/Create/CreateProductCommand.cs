using Ambev.DeveloperEvaluation.Entity.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Product.Create
{
    public class CreateProductCommand : IRequest<CreateProductResult>
    {
        #region properties

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;

        #endregion

        #region methods

        public ValidationResult Validate()
        {
            var validator = new CreateProductValidator();
            var result = validator.Validate(this);
            return new ValidationResult
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationError)o)
            };
        }

        #endregion
    }

}
