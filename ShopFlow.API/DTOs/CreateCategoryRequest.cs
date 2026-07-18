namespace ShopFlow.API.DTOs;

public record CreateCategoryRequest
    (
        string Name,
        string Description
        );