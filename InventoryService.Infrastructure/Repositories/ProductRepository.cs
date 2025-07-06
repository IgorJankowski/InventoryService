using InventoryService.Application.Interfaces.repo;
using InventoryService.Domain.Entities;
using InventoryService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly InventoryDbContext _context;

    public ProductRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task AddAsync(Product Product)
    {
        await _context.Products.AddAsync(Product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product Product)
    {
        _context.Products.Update(Product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var Product = await _context.Products.FindAsync(id);
        if (Product != null)
        {
            _context.Products.Remove(Product);
            await _context.SaveChangesAsync();
        }
    }
}
