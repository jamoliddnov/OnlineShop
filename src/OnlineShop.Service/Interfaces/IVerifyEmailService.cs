using OnlineShop.Service.ViewModels.User;

namespace OnlineShop.Service.Interfaces
{
	public interface IVerifyEmailService
	{
		Task SendCodeAsync(SendCodeToEmailViewModel email);


	}
}
