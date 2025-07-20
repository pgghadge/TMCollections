namespace TMCollections_Api.Models
{
    public class Address
    {

        public Guid Id { get; set; } // Unique identifier for the address

        public Guid UserId { get; set; } // Foreign key to User

        public User User { get; set; } // Navigation property to User


        public string Street { get; set; } // Street address


        public string City { get; set; } // City of the address


        public string State { get; set; }


        public String PostalCode { get; set; } // Postal code of the address

    }
}
