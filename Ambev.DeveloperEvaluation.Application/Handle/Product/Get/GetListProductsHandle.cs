using Ambev.DeveloperEvaluation.UoW.Interface;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Product.Get;

public class GetListProductsHandle : IRequestHandler<GetListProductCommand, IEnumerable<GetProductResult>>
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;

    public GetListProductsHandle(IUoW uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetProductResult>> Handle(GetListProductCommand request, CancellationToken cancellationToken)
    {
        var user = await _uow.ProductRepository.GetAllAsync(cancellationToken);
        return user == null ? throw new KeyNotFoundException("No records of users found") : _mapper.Map<IEnumerable<GetProductResult>>(user);
    }
}
