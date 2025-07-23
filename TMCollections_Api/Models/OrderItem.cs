namespace TMCollections_Api.Models
{
    public class OrderItem
    {

        public Guid Id { get; set; } // Unique identifier for the order item
        public Guid OrderId { get; set; } // Foreign key to Order
        public Order? Order { get; set; } // Navigation property to Order
        public Guid  ProductId { get; set; } // Foreign key to Product
        public Product Product { get; set; } // Navigation property to Product
        public int Quantity { get; set; } // Quantity of the product in the order
        public decimal Price { get; set; } // Price of the product at the time of order

    }
}
