using InventoryService.Application.DTOs;

namespace InventoryService.Application.Interfaces.Services;

public interface IInventoryService
{
    Task<Guid> CreateItemAsync(string name, decimal price, int quantity, Guid categoryId, string? description = null);
    //Task<List<ItemDto>> GetAllItemsAsync();
    //Task UpdateItemQuantityAsync(Guid itemId, int newQuantity);
    //Task DeleteItemAsync(Guid itemId);
}
