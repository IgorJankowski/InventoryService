namespace InventoryService.Application.DTOs;

public record ItemDto(
    Guid Id,
    string Name,
    decimal Price,
    int Quantity,
    string? Description,
    Guid CategoryId
);
