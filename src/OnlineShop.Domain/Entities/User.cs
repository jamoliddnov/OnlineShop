using OnlineShop.DataAccess.Interfaces.Common;
using OnlineShop.Domain.Enums;

namespace OnlineShop.Domain.Entities
{
	public class User : BaseEntity
	{
		public string FullName { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public bool IsEmailConfirmed { get; set; }
		public string PasswordHash { get; set; } = string.Empty;
		public string Salt { get; set; } = string.Empty;
		public string ImagePath { get; set; } = string.Empty;
		public UserRole Role { get; set; } = UserRole.User;
	}
}
