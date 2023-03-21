using OnlineShop.Domain.Entities;

namespace OnlineShop.DataAccess.Interfaces
{
	public interface ISavedAdRepositorie
	{
		public void Create(SavedAd entity);
		public void Delete(long id);
		public Task<IEnumerable<SavedAd>> GetAllSavedAdAsync();
	}
}
