using MediatR;
using ShopFlow.Domain.Entity;
using ShopFlow.Application.Interface;

namespace ShopFlow.Application.Features.Products.Queries;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IReadOnlyList<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IReadOnlyList<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetAllAsync();
    }
}