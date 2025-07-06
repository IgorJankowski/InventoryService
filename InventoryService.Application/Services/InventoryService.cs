using InventoryService.Application.Interfaces.repo;
using InventoryService.Application.Interfaces.Services;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.Services;

public class InventoryService : IInventoryService
{
    private readonly IProductRepository ProductRepository;

    public InventoryService(IProductRepository ProductRepository)
    {
        this.ProductRepository = ProductRepository;
    }

    public async Task<Guid> CreateProductAsync(string name, decimal price, int quantity, Guid? categoryId = null, string? description = null)
    {
        var Product = new Product(name, price, quantity, categoryId, description);
        await ProductRepository.AddAsync(Product);
        return Product.Id;
    }
}
