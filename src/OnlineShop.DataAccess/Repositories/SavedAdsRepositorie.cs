using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.Domain.Entities;

namespace OnlineShop.DataAccess.Repositories
{
    public class SavedAdsRepositorie : ISavedAdRepositorie
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbcontext;
        private readonly DbSet<SavedAd> _dbSet;

        public SavedAdsRepositorie(AppDbContext context, IMapper mapper)
        {
            this._mapper = mapper;
            _dbcontext = context;
            _dbSet = context.SavedAds;
        }

        public void Create(SavedAd entity)
        {
            try
            {
                _dbSet.Add(entity);
                _dbcontext.SaveChanges();
            }
            catch
            {

            }

        }



        public void Delete(long id)
        {
            var entiry = _dbSet.Find(id);
            if (entiry is not null)
            {
                _dbSet.Remove(entiry);
                _dbcontext.SaveChanges();
            }
        }

        public async Task<IEnumerable<SavedAd>> GetAllSavedAdAsync()
        {
            try
            {
                var query = from order in _dbSet.Include(x => x.User).Include(x => x.Announcement)
                            orderby order.AnnouncementId
                            select _mapper.Map<SavedAd>(order);
                return query;
            }
            catch
            {
                return null;
            }
        }
    }
}
