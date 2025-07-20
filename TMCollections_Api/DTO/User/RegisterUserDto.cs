using TMCollections_Api.Models;

namespace TMCollections_Api.DTO.User
{
    public class RegisterUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.Customer; // Default role is User
    }
}
