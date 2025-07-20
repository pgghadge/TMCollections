namespace TMCollections_Api.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; } // Foreign key to Cart
        public Guid ProductId { get; set; } // Foreign key to Product
        public int Quantity { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public Cart Cart { get; set; } // Navigation property to Cart
        public Product Product { get; set; } // Navigation property to Product
        
    }
}
