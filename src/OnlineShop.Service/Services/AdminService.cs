using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DataAccess.Interfaces.Common;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.Services.Common.PaginationServices;
using OnlineShop.Service.ViewModels;

#pragma warning disable

namespace OnlineShop.Service.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
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

        public async Task<PageList<AnnouncementViewModel>> GetAllAsyncAdmin(int number, PaginationParams @paginationParams)
        {

            if (number == 0)
            {
                var query = from announcement in _unitOfWork.Announcements.Where(x => x.LiceCount == 0).OrderBy(x => x.Id)
                            select _mapper.Map<AnnouncementViewModel>(announcement);

                var result = await PageList<AnnouncementViewModel>.ToPageListAsync(query, paginationParams);

                foreach (var user in result)
                {
                    var userQuery = await _unitOfWork.Users.Where(x => x.Id == user.UserId).AsNoTracking().ToListAsync();
                    foreach (var item in userQuery)
                    {
                        user.UserName = item.FullName;
                    }
                }
                return result;
            }
            else if (number == 1)
            {
                var query = from announcement in _unitOfWork.Announcements.Where(x => x.LiceCount == 1).OrderBy(x => x.Id)
                            select _mapper.Map<AnnouncementViewModel>(announcement);

                var result = await PageList<AnnouncementViewModel>.ToPageListAsync(query, paginationParams);

                foreach (var user in result)
                {
                    var userQuery = await _unitOfWork.Users.Where(x => x.Id == user.UserId).AsNoTracking().ToListAsync();
                    foreach (var item in userQuery)
                    {
                        user.UserName = item.FullName;
                    }
                }
                return result;
            }

            return null;
        }

        public async Task GetAllAsyncAdminAdd(long id)
        {
            var query = await _unitOfWork.Announcements.FirstByIdAsync(id);
            _unitOfWork.Announcements.TrackingDeteched(query);
            query.LiceCount = 1;
            _unitOfWork.Announcements.Update(id, query);
            var res = await _unitOfWork.SaveChangesAsync();
        }

        public async Task GetAllAsyncAdminRemove(long id)
        {
            var query = await _unitOfWork.Announcements.FirstByIdAsync(id);
            _unitOfWork.Announcements.TrackingDeteched(query);
            query.LiceCount = 2;
            _unitOfWork.Announcements.Update(id, query);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PageList<UserViewModel>> GetAllAsyncCustomer(PaginationParams @paginationParams)
        {
            var query = from user in _unitOfWork.Users.GetAll().Where(x => x.Role == 0)
                        select _mapper.Map<UserViewModel>(user);

            return await PageList<UserViewModel>.ToPageListAsync(query, paginationParams);
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
