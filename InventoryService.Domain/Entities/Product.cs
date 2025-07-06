namespace InventoryService.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public Guid? CategoryId { get; private set; }
        public virtual Category Category { get; private set; }

        private Product() { }

        public Product(string name, decimal price, int quantity, Guid? categoryId = null, string? description = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));
            if (price < 0)
                throw new ArgumentException("Price cannot be negative.", nameof(price));
            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));

            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Quantity = quantity;
            Description = description;
            CategoryId = categoryId;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity < 0)
                throw new ArgumentException("Quantity cannot be negative.", nameof(newQuantity));

            Quantity = newQuantity;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0)
                throw new ArgumentException("Price cannot be negative.", nameof(newPrice));

            Price = newPrice;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateDescription(string? newDescription)
        {
            Description = newDescription;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Name cannot be empty.", nameof(newName));

            Name = newName;
            UpdatedAt = DateTime.UtcNow;
        }
        public void AddStock(int amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive.");
            Quantity += amount;
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveStock(int amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive.");
            if (Quantity - amount < 0) throw new InvalidOperationException("Insufficient stock.");
            Quantity -= amount;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
