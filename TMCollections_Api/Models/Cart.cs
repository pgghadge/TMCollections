namespace TMCollections_Api.Models
{
    public class Cart
    {

        public Guid Id { get; set; } 
        public Guid UserId { get; set; } // Foreign key to User
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public User User { get; set; } // Navigation property to User
        public ICollection<CartItem> CartItems { get; set; } // Collection of items in the cart
    }
}
