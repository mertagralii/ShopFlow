using MediatR;
using ShopFlow.Application.Interface;
using ShopFlow.Domain.Entity;

namespace ShopFlow.Application.Features.Categories.Queries.GetAllCategory;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IReadOnlyList<Category>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IReadOnlyList<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetAllAsync();
    }
}