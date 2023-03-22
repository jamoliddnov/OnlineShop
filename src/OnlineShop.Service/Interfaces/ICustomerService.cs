using OnlineShop.Service.ViewModels;

namespace OnlineShop.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerAnnouncementViewModel> GetByIdAsync(int id);
        Task<long> UpdateAsync(CustomerAnnouncementViewModel model);
    }
}
