using Ambev.DeveloperEvaluation.ORM.Repository.Interface;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Delete
{
    public class DeleteProductsInCartHandler : IRequestHandler<DeleteProductsInCartCommand, DeleteProductsInCartResponse>
    {
        #region atributes

        private readonly IProductsInCartRepository _repository;

        #endregion

        #region constructors

        public DeleteProductsInCartHandler(IProductsInCartRepository repository) => _repository = repository;

        #endregion

        #region methods

        /// <summary>
        /// handle for delete command
        /// </summary>
        /// <param name="request">required ProductsInCart id</param>
        /// <param name="cancellationToken">cancelation token registered after deletion errors</param>
        /// <returns>returns delete operation</returns>
        /// <exception cref="ValidationException">validation getting the system operation exception</exception>
        /// <exception cref="KeyNotFoundException">parameter id getting the system operation exception</exception>
        public async Task<DeleteProductsInCartResponse> Handle(DeleteProductsInCartCommand request, CancellationToken cancellationToken)
        {
            // variable creation block
            var validator = new DeleteProductsInCartValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            // condition for validation before deletion
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // prepare the ProductsInCart record for deletion command
            var sucess = await _repository.DeleteAsync(request.CartId, request.ProductId, cancellationToken);
            
            // condition for deletion command acomplishment
            if (!sucess)
                throw new KeyNotFoundException($"Cart with ID {request.CartId} and Product with Id {request.ProductId} not found");

            return new DeleteProductsInCartResponse { Success = sucess };
        }

        #endregion
    }
}
