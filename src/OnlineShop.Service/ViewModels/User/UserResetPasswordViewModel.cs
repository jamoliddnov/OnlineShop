using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineShop.Service.ViewModels.User
{
	public class UserResetPasswordViewModel
	{
		[Required, EmailAddress]
		[JsonPropertyName("email")]
		public string Email { get; set; } = string.Empty;

		[Required]
		[JsonPropertyName("code")]
		public uint Code { get; set; }

		[Required(ErrorMessage = "Password is required"), MinLength(8), MaxLength(50)]
		//[StrongPassword]
		[JsonPropertyName("password")]
		public string Password { get; set; } = string.Empty;
	}
}
