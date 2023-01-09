using OnlineShop.Service.ViewModels.User;

namespace OnlineShop.Service.Interfaces
{
    public interface IEmailService
    {
        public Task SendAsync(EmailMessageViewModel emailMessage);
    }
}
