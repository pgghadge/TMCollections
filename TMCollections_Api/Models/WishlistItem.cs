namespace TMCollections_Api.Models
{
    public class WishlistItem
    {
        public Guid Id { get; set; } // Unique identifier for the wishlist item'

        public Guid WishlistId { get; set; } // Foreign key to Wishlist

        public Wishlist Wishlist { get; set; } // Navigation property to Wishlist

        public Guid ProductId { get; set; } // Foreign key to Product

        public Product Product { get; set; } // Navigation property to Product
    }
}
