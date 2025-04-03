using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.User.Get;
public record GetListUserCommand : IRequest<IEnumerable<GetUserResult>>
{
}