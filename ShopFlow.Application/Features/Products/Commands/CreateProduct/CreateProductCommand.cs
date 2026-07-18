using MediatR;

namespace ShopFlow.Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand(
    Guid CategoryId,
    string Name,
    decimal Price,
    int Stock,
    string Description
) : IRequest<Guid>;



