namespace TMCollections_Api.DTO.Cart
{
    public class AddCartItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
