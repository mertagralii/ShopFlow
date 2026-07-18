using MediatR;
using ShopFlow.Application.Interface;

namespace ShopFlow.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Domain.Entity.Category(request.Name, request.Description);
        await _categoryRepository.AddAsync(category);
        return category.Id;
    }
}