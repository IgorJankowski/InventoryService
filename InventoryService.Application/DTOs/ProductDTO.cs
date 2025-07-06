namespace InventoryService.Application.DTOs;

public record ProductDto(
    Guid Id,
    string Name,
    decimal Price,
    int Quantity,
    string? Description,
    Guid CategoryId
);
