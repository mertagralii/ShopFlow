using MediatR;
using ShopFlow.Domain.Entity;

namespace ShopFlow.Application.Features.Products.Queries.GetProductById;

public record GetProductByIdQuery(Guid Id) : IRequest<Product?>;