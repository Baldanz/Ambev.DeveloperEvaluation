using Ambev.DeveloperEvaluation.UoW.Interface;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Get;

public class GetListProductsInSalesHandle : IRequestHandler<GetListProductsInSalesCommand, IEnumerable<GetProductsInSalesResult>>
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;

    public GetListProductsInSalesHandle(IUoW uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetProductsInSalesResult>> Handle(GetListProductsInSalesCommand request, CancellationToken cancellationToken)
    {
        var cart = await _uow.ProductsInSalesRepository.GetAllAsync(cancellationToken);
        return cart == null ? throw new KeyNotFoundException("No records of users found") : _mapper.Map<IEnumerable<GetProductsInSalesResult>>(cart);
    }
}
