using OnlineShop.Service.ViewModels.User;

namespace OnlineShop.Service.Interfaces
{
    public interface IVerifyEmailService
    {
        Task SendCodeAsync(SendCodeToEmailViewModel email);

        Task VerifyEmail(EmailVerifyViewModel emailVerify);

        Task VerifyPasswordAsync(UserResetPasswordViewModel model);
    }
}
