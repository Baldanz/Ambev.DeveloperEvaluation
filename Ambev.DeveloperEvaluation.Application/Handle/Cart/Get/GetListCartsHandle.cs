using Ambev.DeveloperEvaluation.UoW.Interface;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Cart.Get;

public class GetListCartsHandle : IRequestHandler<GetListCartCommand, IEnumerable<GetCartResult>>
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;

    public GetListCartsHandle(IUoW uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetCartResult>> Handle(GetListCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await _uow.CartRepository.GetAllAsync(cancellationToken);
        return cart == null ? throw new KeyNotFoundException("No records of users found") : _mapper.Map<IEnumerable<GetCartResult>>(cart);
    }
}
