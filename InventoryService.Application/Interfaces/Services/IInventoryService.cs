using InventoryService.Application.DTOs;

namespace InventoryService.Application.Interfaces.Services;

public interface IInventoryService
{
    Task<Guid> CreateProductAsync(string name, decimal price, int quantity, Guid? categoryId = null, string? description = null);
    Task<List<ProductDto>> GetAllProductsAsync();
    //Task UpdateProductQuantityAsync(Guid ProductId, int newQuantity);
    //Task DeleteProductAsync(Guid ProductId);
}
