﻿namespace TMCollections_Api.Models
{
    public class Order
    {
        public Guid Id { get; set; }  // Unique identifier for the order
        public Guid UserId { get; set; } // Foreign key to User
        public User User { get; set; } // Navigation property to User
        public DateTime OrderDate { get; set; } = DateTime.UtcNow; // Date and time when the order was created
        public decimal TotalAmount { get; set; }
        public OrderStatus status { get; set; } = OrderStatus.Pending;
        // Status of the order (e.g., Pending, Shipped, Delivered, Cancelled)
        
        public ICollection<OrderItem> OrderItems { get; set; } // Collection of items in the order
        public Payment Payment { get; set; } // One-to-One navigation


    }
}
