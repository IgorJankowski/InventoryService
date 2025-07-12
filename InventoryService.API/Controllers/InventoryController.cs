using InventoryService.Application.Interfaces.Services;
using InventoryService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.API.Controllers
{
    public record AddProductRecord(string ProductName, int Quantity, string? Category, string? Description);

    [ApiController]
    [Route("inventory")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRecord request)
        {
            await _inventoryService.CreateProductAsync(
                request.ProductName,
                0,
                request.Quantity,
                null,
                request.Description
            );

            return Ok(new
            {
                Message = "Product added",
                Product = request
            });
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _inventoryService.GetAllProductsAsync();
            return Ok(products);
        }
    }
}