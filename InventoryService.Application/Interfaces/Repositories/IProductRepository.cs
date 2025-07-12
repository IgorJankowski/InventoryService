using InventoryService.Domain.Entities;

namespace InventoryService.Application.Interfaces.repo;

public interface IProductRepository
{
    //Task<Product?> GetByIdAsync(Guid id);
    Task<List<Product>> GetAllAsync();
    Task AddAsync(Product Product);
    //Task UpdateAsync(Product Product);
    //Task DeleteAsync(Guid id);
    //Task<bool> ExistsAsync(Guid id);
}
