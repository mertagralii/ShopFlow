using MediatR;
using ShopFlow.Domain.Entity;

namespace ShopFlow.Application.Features.Products.Queries;

public record GetAllProductsQuery() : IRequest<IReadOnlyList<Product>>;