using MediatR;
using ShopFlow.Application.Interface;
using ShopFlow.Domain.Entity;

namespace ShopFlow.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.CategoryId, request.Name, request.Price, request.Stock, request.Description);
        await _productRepository.AddAsync(product);
        return product.Id;
    }

}