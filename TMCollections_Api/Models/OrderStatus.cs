namespace TMCollections_Api.Models
{
    public enum OrderStatus
    {
        Pending,    // Order has been placed but not yet processed
        Processing, // Order is being prepared or processed
        Shipped,    // Order has been shipped to the customer
        Delivered,  // Order has been delivered to the customer
        Cancelled,  // Order has been cancelled by the customer or the system
    }
}
