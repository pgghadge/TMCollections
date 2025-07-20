namespace TMCollections_Api.Models
{
    public class Wishlist
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
      
        public ICollection<WishlistItem> WishlistItems { get; set; } // Add this property
    }
}
