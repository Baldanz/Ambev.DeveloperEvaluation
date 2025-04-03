using Ambev.DeveloperEvaluation.UoW.Interface;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.User.Get;

public class GetListUsersHandle : IRequestHandler<GetListUserCommand, IEnumerable<GetUserResult>>
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;

    public GetListUsersHandle(IUoW uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetUserResult>> Handle(GetListUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _uow.UserRepository.GetAllAsync(cancellationToken);
        return user == null ? throw new KeyNotFoundException("No records of users found") : _mapper.Map<IEnumerable<GetUserResult>>(user);
    }
}
