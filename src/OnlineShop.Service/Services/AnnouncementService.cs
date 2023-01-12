using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.DataAccess.Interfaces.Common;
using OnlineShop.Domain.Entities;
using OnlineShop.Service.Interfaces;

namespace OnlineShop.Service.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnnouncementService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;

        }

        public async Task<bool> CreateAsync(Announcement announcement)
        {
            try
            {
                announcement.CreateAt = DateTime.UtcNow.ToString();
                announcement.UserId = 1;
                announcement.CategoryId = 1;
                announcement.LiceCount = 0;

                _unitOfWork.Announcements.Create(announcement);
                var res = await _unitOfWork.SaveChangesAsync();
                return res > 0;
            }
            catch
            {
                return false;
            }
        }



        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                _unitOfWork.Announcements.Delete(id);
                _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }


        public async Task<IEnumerable<Announcement>> GetAllAsync()
        {
            var resault = _unitOfWork.Announcements.GetAll();
            return resault;
        }

        public async Task<Announcement> GetByIdAsync(long id)
        {
            var resault = await _unitOfWork.Announcements.FirstByIdAsync(id);
            return resault;
        }

        public async Task<bool> UpdateAsync(long id, Announcement announcement)
        {
            try
            {


                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
