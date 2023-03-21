using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Service.ViewModels.User
{
	public class SendCodeToEmailViewModel
	{
		[Required, EmailAddress]
		public string Email { get; set; } = string.Empty;
	}
}
