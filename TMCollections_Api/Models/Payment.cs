namespace TMCollections_Api.Models
{
    public class Payment
    {
        public Guid Id { get; set; } // Unique identifier for the payment

        public Guid OrderId { get; set; } // Foreign key to Order

        public Order Order { get; set; } // Navigation property to Order

        public Guid UserId { get; set; }
        public User User { get; set; }
        public decimal Amount { get; set; } // Amount of the payment

        public DateTime PaymentDate { get; set; } // Date and time when the payment was made

        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;


    }
}
