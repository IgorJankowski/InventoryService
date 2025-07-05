using InventoryService.Application.Interfaces.repo;
using InventoryService.Application.Interfaces.Services;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.Services;

public class InventoryService : IInventoryService
{
    private readonly IItemRepository itemRepository;

    public InventoryService(IItemRepository itemRepository)
    {
        this.itemRepository = itemRepository;
    }

    public async Task<Guid> CreateItemAsync(string name, decimal price, int quantity, Guid categoryId, string? description = null)
    {
        var item = new Item(name, price, quantity, categoryId, description);
        //await itemRepository.AddAsync(item);
        return item.Id;
    }
}
