using Ambev.DeveloperEvaluation.Domain.Model;
using Ambev.DeveloperEvaluation.ORM.Repository.Interface;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.User.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
    {
        #region atributes

        private readonly IUserRepository _repository;

        #endregion

        #region constructors

        public DeleteUserHandler(IUserRepository repository) => _repository = repository;

        #endregion

        #region methods

        /// <summary>
        /// handle for delete command
        /// </summary>
        /// <param name="request">required user id</param>
        /// <param name="cancellationToken">cancelation token registered after deletion errors</param>
        /// <returns>returns delete operation</returns>
        /// <exception cref="ValidationException">validation getting the system operation exception</exception>
        /// <exception cref="KeyNotFoundException">parameter id getting the system operation exception</exception>
        public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            // variable creation block
            var validator = new DeleteUserValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            // condition for validation before deletion
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // prepare the user record for deletion command
            var sucess = await _repository.DeleteAsync(request.Id, cancellationToken);
            
            // condition for deletion command acomplishment
            if (!sucess)
                throw new KeyNotFoundException($"User with ID {request.Id} not found");

            return new DeleteUserResponse { Success = sucess };
        }

        #endregion
    }
}
