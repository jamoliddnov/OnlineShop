using Microsoft.AspNetCore.Server.IIS.Core;
using OnlineShop.DataAccess.Interfaces.Common;
using OnlineShop.Domain.Entities;
using OnlineShop.Service.Common.Utils;
using OnlineShop.Service.Dtos.Announcement;
using OnlineShop.Service.Interfaces;

namespace OnlineShop.Service.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        

        public AnnouncementService(IUnitOfWork unitOfWork, IFileService fileService)
        {
            this._unitOfWork = unitOfWork;
            this._fileService = fileService;
        }

        public async Task<bool> CreateAsync(CreateAnnouncementDto announcements)
        {
            try
            {
                var announcement = (Announcement)announcements;

                announcement.CreateAt = DateTime.UtcNow.ToString();
                announcement.UserId = 1;
                announcement.LiceCount = 0;

                if (announcements.Image is not null)
                {
                    announcement.ImagePath = await _fileService.SaveImageAsync(announcements.Image);
                }

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


        public async Task<IEnumerable<Announcement>> GetAllAsync(PaginationParams @paginationParams)
        {
            var resault = _unitOfWork.Announcements.GetAll();
            return resault;
        }

        public Task<IEnumerable<Announcement>> GetAllByIdAsync(int id)
        {
            throw new NotImplementedException();
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
                announcement.CreateAt = DateTime.UtcNow.ToString();
                announcement.UserId = 2;
                announcement.LiceCount = 0;


                _unitOfWork.Announcements.Update(id, announcement);
                var res = await _unitOfWork.SaveChangesAsync();
                return res > 0;

            }
            catch
            {
                return false;
            }
        }


    }
}
