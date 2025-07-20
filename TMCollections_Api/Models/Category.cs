namespace TMCollections_Api.Models
{
    public class Category
    {

        public Guid Id { get; set; } // Unique identifier for the category
        public string Name { get; set; } // Name of the category, e.g., "Electronics", "Books", etc.
        public ICollection<Product> Products { get; set; } // Navigation property to related products
    }
}

