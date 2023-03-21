using OnlineShop.DataAccess.Interfaces.Common;
using OnlineShop.Domain.Enums;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ViewModels;

#pragma warning disable

namespace OnlineShop.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<CustomerAnnouncementViewModel> GetByIdAsync(int id)
        {
            var resultAnnouncemnt = await _unitOfWork.Announcements.FirstByIdAsync(id);
            CustomerAnnouncementViewModel customer = new CustomerAnnouncementViewModel();

            customer.Id = id;
            customer.PhoneNumber = resultAnnouncemnt.PhoneNumber;
            customer.ImagePath = resultAnnouncemnt.ImagePath;
            customer.Price = resultAnnouncemnt.Price;
            customer.Title = resultAnnouncemnt.Title;
            customer.Description = resultAnnouncemnt.Description;

            switch (resultAnnouncemnt.CategoryId)
            {
                case 1:
                    customer.Category = Categorys.Hayvonlar.ToString();
                    break;
                case 2:
                    customer.Category = Categorys.Elektronika.ToString();
                    break;
                case 3:
                    customer.Category = "Kiyim - kechak";
                    break;
                case 4:
                    customer.Category = Categorys.Uy.ToString();
                    break;
                case 5:
                    customer.Category = Categorys.Avtomabil.ToString();
                    break;
                case 6:
                    customer.Category = "Bolalar uchun";
                    break;
                default:
                    break;
            }

            if (resultAnnouncemnt is not null)
            {
                return customer;
            }
            return null;
        }
    }
}
