using InventoryService.Application.DTOs;
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

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await ProductRepository.GetAllAsync();
        var productDtos = products.Select(p => new ProductDto(
            p.Id,
            p.Name,
            p.Price,
            p.Quantity,
            p.Description,
            p.CategoryId
        )).ToList();

        return productDtos;
    }
}
