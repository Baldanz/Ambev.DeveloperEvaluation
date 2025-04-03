using Ambev.DeveloperEvaluation.Application.Handle.User.Get;
using Ambev.DeveloperEvaluation.UoW.Interface;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Get;

public class GetListProductsInCartsHandle : IRequestHandler<GetListProductsInCartCommand, IEnumerable<GetProductsInCartResult>>
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;

    public GetListProductsInCartsHandle(IUoW uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetProductsInCartResult>> Handle(GetListProductsInCartCommand request, CancellationToken cancellationToken)
    {
        var productCart = await _uow.ProductsInCartRepository.GetAllAsync(cancellationToken);
        return productCart == null ? throw new KeyNotFoundException("No records of users found") : _mapper.Map<IEnumerable<GetProductsInCartResult>>(productCart);
    }
}