using Ambev.DeveloperEvaluation.ORM.Repository.Interface;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Cart.Delete
{
    public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResponse>
    {
        #region atributes

        private readonly ICartRepository _repository;

        #endregion

        #region constructors

        public DeleteCartHandler(ICartRepository repository) => _repository = repository;

        #endregion

        #region methods

        /// <summary>
        /// handle for delete command
        /// </summary>
        /// <param name="request">required Cart id</param>
        /// <param name="cancellationToken">cancelation token registered after deletion errors</param>
        /// <returns>returns delete operation</returns>
        /// <exception cref="ValidationException">validation getting the system operation exception</exception>
        /// <exception cref="KeyNotFoundException">parameter id getting the system operation exception</exception>
        public async Task<DeleteCartResponse> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            // variable creation block
            var validator = new DeleteCartValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            // condition for validation before deletion
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // prepare the Cart record for deletion command
            var sucess = await _repository.DeleteAsync(request.Id, cancellationToken);
            
            // condition for deletion command acomplishment
            if (!sucess)
                throw new KeyNotFoundException($"Cart with ID {request.Id} not found");

            return new DeleteCartResponse { Success = sucess };
        }

        #endregion
    }
}
