namespace ShopFlow.API.DTOs;

public record CategoryResponse
(
    Guid Id,
    string Name,
    string Description,
    DateTime CreatedAt
);