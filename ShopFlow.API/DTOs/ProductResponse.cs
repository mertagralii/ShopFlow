namespace ShopFlow.API.DTOs;

public record ProductResponse(
    Guid Id,
    Guid CategoryId,
    string Name,
    decimal Price,
    int Stock,
    string Description,
    bool IsActive,
    DateTime  CreatedAt
);