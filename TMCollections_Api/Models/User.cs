namespace TMCollections_Api.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // e.g., "Admin", "User"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        // Additional properties can be added as needed

        public ICollection<Address> Addresses { get; set; } 

        public Cart cart { get; set; } // Navigation property to Cart   

        public Wishlist wishlist { get; set; } // Navigation property to Wishlist

        public ICollection<Order> Orders { get; set; } // Navigation property to Orders

        public ICollection<Payment> Payments { get; set; } // Navigation property to Payments   
    }
}
