namespace InventoryService.Application.DTOs;

public record ProductDto(
    Guid Id,
    string Name,
    int Quantity,
    string? Description,
    Guid? CategoryId
);
