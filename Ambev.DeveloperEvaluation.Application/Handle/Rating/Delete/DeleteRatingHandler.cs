using Ambev.DeveloperEvaluation.ORM.Repository.Interface;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Rating.Delete;

public class DeleteRatingHandler : IRequestHandler<DeleteRatingCommand, DeleteRatingResponse>
{
    #region atributes

    private readonly IRatingRepository _repository;

    #endregion

    #region constructors

    public DeleteRatingHandler(IRatingRepository repository) => _repository = repository;

    #endregion

    #region methods

    /// <summary>
    /// handle for delete command
    /// </summary>
    /// <param name="request">required Rating id</param>
    /// <param name="cancellationToken">cancelation token registered after deletion errors</param>
    /// <returns>returns delete operation</returns>
    /// <exception cref="ValidationException">validation getting the system operation exception</exception>
    /// <exception cref="KeyNotFoundException">parameter id getting the system operation exception</exception>
    public async Task<DeleteRatingResponse> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
    {
        // variable creation block
        var validator = new DeleteRatingValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        // condition for validation before deletion
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        // prepare the Rating record for deletion command
        var sucess = await _repository.DeleteAsync(request.Id, cancellationToken);
        
        // condition for deletion command acomplishment
        if (!sucess)
            throw new KeyNotFoundException($"Rating with ID {request.Id} not found");

        return new DeleteRatingResponse { Success = sucess };
    }

    #endregion
}
