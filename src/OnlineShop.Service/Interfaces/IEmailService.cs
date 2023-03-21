using OnlineShop.Service.ViewModels.User;

namespace OnlineShop.Service.Interfaces
{
	public interface IEmailService
	{
		public Task<bool> SendAsync(EmailMessageViewModel message);
	}
}
