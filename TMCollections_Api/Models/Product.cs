namespace TMCollections_Api.Models
{
    public class Product
    {
        

        public Guid Id { get; set; } =  Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Brand { get; set; }
        public bool? IsAvailable { get; set; } 
        public Guid CategoryId { get; set; } // ✅ FK to Category
        public Category Category { get; set; } // e.g., "Electronics", "Books", etc.
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<WishlistItem> WishlistItems { get; set; }
        public int StockQuantity { get; set; } // Number of items available in stock
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        // Additional properties can be added as needed
    }
}
