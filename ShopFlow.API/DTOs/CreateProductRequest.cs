namespace ShopFlow.API.DTOs;

public record CreateProductRequest(
    Guid CategoryId,
    string Name,
    decimal Price,
    int Stock,
    string Description
    );