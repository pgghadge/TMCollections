namespace TMCollections_Api.DTO.Payment
{
    public class CreatePaymentDto
    {
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
    }
}
