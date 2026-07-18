using MediatR;
using ShopFlow.Domain.Entity;

namespace ShopFlow.Application.Features.Categories.Queries.GetAllCategory;

public record GetAllCategoryQuery() : IRequest<IReadOnlyList<Category>>;