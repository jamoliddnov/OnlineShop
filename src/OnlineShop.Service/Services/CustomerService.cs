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
        private readonly IFileService _fileService;

        public CustomerService(IUnitOfWork unitOfWork, IFileService fileService)
        {
            this._unitOfWork = unitOfWork;
            this._fileService = fileService;
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

        public async Task<long> UpdateAsync(CustomerAnnouncementViewModel model)
        {
            model.Id = GlobalVariables.UpdateId;
            var resultProdut = await _unitOfWork.Announcements.FirstByIdAsync(model.Id);
            if (resultProdut is not null)
            {
                _unitOfWork.Announcements.TrackingDeteched(resultProdut);



                resultProdut.Id = resultProdut.Id;
                resultProdut.PhoneNumber = model.PhoneNumber;
                resultProdut.Price = model.Price;
                resultProdut.Description = model.Description;
                resultProdut.CreateAt = resultProdut.CreateAt;
                resultProdut.Title = model.Title;
                resultProdut.LiceCount = 0;
                resultProdut.UserId = resultProdut.UserId;
                if (model.Image is not null)
                {
                    resultProdut.ImagePath = await _fileService.SaveImageAsync(model.Image);
                }
                else
                {
                    resultProdut.ImagePath = model.ImagePath;
                }

                if (model.Category.Length > 1)
                {
                    if (model.Category == "Kiyim - kechak")
                    {
                        resultProdut.CategoryId = 3;
                    }
                    else if (model.Category == "Bolalar uchun")
                    {
                        resultProdut.CategoryId = 6;
                    }
                    else
                    {
                        switch (model.Category)
                        {
                            case "Hayvonlar":
                                resultProdut.CategoryId = 1;
                                break;
                            case "Elektronika":
                                resultProdut.CategoryId = 2;
                                break;
                            case "Uy":
                                resultProdut.CategoryId = 4;
                                break;
                            case "Avtomabil":
                                resultProdut.CategoryId = 5;
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    resultProdut.CategoryId = int.Parse(model.Category);
                }

                _unitOfWork.Announcements.Update(resultProdut.Id, resultProdut);
                var result = await _unitOfWork.SaveChangesAsync();
                if (result > 0)
                {
                    return GlobalVariables.UpdateId;
                }
            }
            return 0;
        }


    }
}
