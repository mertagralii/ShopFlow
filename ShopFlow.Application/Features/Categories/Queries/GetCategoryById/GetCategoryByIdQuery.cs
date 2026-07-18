using MediatR;
using ShopFlow.Domain.Entity;

namespace ShopFlow.Application.Features.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid Id) : IRequest<Category?>;