using Ambev.DeveloperEvaluation.UoW.Interface;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Sales.Get;

public class GetListSalesHandle : IRequestHandler<GetListSalesCommand, IEnumerable<GetSalesResult>>
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;

    public GetListSalesHandle(IUoW uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetSalesResult>> Handle(GetListSalesCommand request, CancellationToken cancellationToken)
    {
        var cart = await _uow.SalesRepository.GetAllAsync(cancellationToken);
        return cart == null ? throw new KeyNotFoundException("No records of users found") : _mapper.Map<IEnumerable<GetSalesResult>>(cart);
    }
}
