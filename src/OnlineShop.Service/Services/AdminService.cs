using Microsoft.EntityFrameworkCore;
using OnlineShop.DataAccess.Interfaces.Common;
using OnlineShop.Domain.Entities;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.ViewModels;

#pragma warning disable

namespace OnlineShop.Service.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> CustomerRemove(long id)
        {
            var customerUser = await _unitOfWork.Announcements.Where(x => x.UserId == id).AsNoTracking().ToListAsync();

            foreach (var customer in customerUser)
            {
                _unitOfWork.Announcements.Delete(customer.Id);
            }

            _unitOfWork.Users.Delete(id);

            var result = await _unitOfWork.SaveChangesAsync();

            return result > 0;
        }

        public async Task<IList<AnnouncementViewModel>> GetAllAsyncAdmin(int number)
        {
            IList<AnnouncementViewModel> list = new List<AnnouncementViewModel>();
            if (number == 0)
            {
                var query = await _unitOfWork.Announcements.GetAll().Where(x => x.LiceCount == 0).OrderBy(x => x.Id).AsNoTracking().ToListAsync();
                foreach (var item in query)
                {
                    List<User> user = (List<User>)await _unitOfWork.Users.GetAll().Where(x => x.Id == item.UserId).AsNoTracking().ToListAsync();

                    AnnouncementViewModel announcementViewModel = new AnnouncementViewModel();
                    announcementViewModel.Id = item.Id;
                    announcementViewModel.Title = item.Title;
                    announcementViewModel.Price = item.Price;
                    announcementViewModel.PhoneNumber = item.PhoneNumber;
                    announcementViewModel.Description = item.Description;
                    announcementViewModel.ImagePath = item.ImagePath;
                    announcementViewModel.CreateAt = item.CreateAt;
                    foreach (var item2 in user)
                    {
                        announcementViewModel.UserName = item2.FullName;
                    }
                    list.Add(announcementViewModel);
                }
            }
            else if (number == 1)
            {
                var query = await _unitOfWork.Announcements.GetAll().Where(x => x.LiceCount == 1).OrderBy(x => x.Id).AsNoTracking().ToListAsync();
                foreach (var item in query)
                {
                    List<User> user = (List<User>)await _unitOfWork.Users.GetAll().Where(x => x.Id == item.UserId).AsNoTracking().ToListAsync();
                    AnnouncementViewModel announcementViewModel = new AnnouncementViewModel();
                    announcementViewModel.Id = item.Id;
                    announcementViewModel.Title = item.Title;
                    announcementViewModel.Price = item.Price;
                    announcementViewModel.PhoneNumber = item.PhoneNumber;
                    announcementViewModel.Description = item.Description;
                    announcementViewModel.ImagePath = item.ImagePath;
                    announcementViewModel.CreateAt = item.CreateAt;
                    foreach (var item2 in user)
                    {
                        announcementViewModel.UserName = item2.FullName;
                    }
                    list.Add(announcementViewModel);
                }
            }

            return list;
        }

        public async Task GetAllAsyncAdminAdd(long id)
        {
            var query = await _unitOfWork.Announcements.FirstByIdAsync(id);
            _unitOfWork.Announcements.TrackingDeteched(query);
            query.LiceCount = 1;
            _unitOfWork.Announcements.Update(id, query);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task GetAllAsyncAdminRemove(long id)
        {
            var query = await _unitOfWork.Announcements.FirstByIdAsync(id);
            _unitOfWork.Announcements.TrackingDeteched(query);
            query.LiceCount = 2;
            _unitOfWork.Announcements.Update(id, query);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IList<UserViewModel>> GetAllAsyncCustomer()
        {
            IList<UserViewModel> list = new List<UserViewModel>();

            var user = await _unitOfWork.Users.GetAll().Where(x => x.Role == 0).AsNoTracking().ToListAsync();

            if (user is not null)
            {
                foreach (var userViewModel in user)
                {
                    UserViewModel userView = new UserViewModel();

                    userView.Id = userViewModel.Id;
                    userView.UserName = userViewModel.FullName;
                    userView.PhoneNumber = userViewModel.PhoneNumber;
                    userView.Email = userViewModel.Email;

                    var count = from announcement in _unitOfWork.Announcements.Where(x => x.UserId == userViewModel.Id)
                                select announcement.Category;

                    userView.CountPost = count.Count();

                    list.Add(userView);
                }
                return list;
            }
            return null;
        }

        public async Task<AnnouncementViewModel> GetByIdAsync(long id)
        {
            var resault = await _unitOfWork.Announcements.FirstByIdAsync(id);
            if (resault is not null)
            {
                AnnouncementViewModel announcementViewModel = new AnnouncementViewModel();
                announcementViewModel.Id = resault.Id;
                announcementViewModel.Title = resault.Title;
                announcementViewModel.Price = resault.Price;
                announcementViewModel.PhoneNumber = resault.PhoneNumber;
                announcementViewModel.ImagePath = resault.ImagePath;
                announcementViewModel.CreateAt = resault.CreateAt;
                announcementViewModel.Description = resault.Description;
                return announcementViewModel;
            }
            return null;
        }
    }
}
