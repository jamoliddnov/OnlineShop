using OnlineShop.Domain.Enums;

namespace OnlineShop.Domain.Entities.Users
{
    public class User
    {
        public long Id { get; set; }
        public string FullName { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string PasswordHash { get; set; } = String.Empty;
        public string Salt { get; set; } = String.Empty;
        public string ImagePath { get; set; } = String.Empty;
        public UserRole Role { get; set; }
    }
}
