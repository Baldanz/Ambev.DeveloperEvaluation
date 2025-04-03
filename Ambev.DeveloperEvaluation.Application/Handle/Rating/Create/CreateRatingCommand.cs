using Ambev.DeveloperEvaluation.Entity.Validation;
using MediatR;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Application.Handle.Rating.Create
{
    public class CreateRatingCommand : IRequest<CreateRatingResult>
    {
        #region properties

        [JsonIgnore]
        public Nullable<Guid> ProductId { get; set; }
        public int Rate { get; set; }
        public int Count { get; set; }

        #endregion

        #region methods

        public ValidationResult Validate()
        {
            var validator = new CreateRatingValidator();
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
