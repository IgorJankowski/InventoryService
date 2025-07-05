using InventoryService.Application.Interfaces.repo;
using InventoryService.Domain.Entities;
using InventoryService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly InventoryDbContext _context;

    public ItemRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<Item?> GetByIdAsync(Guid id)
    {
        return await _context.Items.FindAsync(id);
    }

    public async Task<List<Item>> GetAllAsync()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task AddAsync(Item item)
    {
        await _context.Items.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Item item)
    {
        _context.Items.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var item = await _context.Items.FindAsync(id);
        if (item != null)
        {
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
