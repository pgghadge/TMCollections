namespace TMCollections_Api.DTO.Order
{
    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public int Quantity { get; set; }
        public decimal PriceAtPurchase { get; set; }
    }
}
