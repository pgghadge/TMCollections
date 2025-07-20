namespace TMCollections_Api.DTO.Cart
{
    public class CartDto
    {
        public Guid CartId { get; set; }

        public Guid UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CartItemDto> Items { get; set; }
        
    }
}
