using OnlineShop.Domain.Entities;

namespace OnlineShop.Service.Dtos.SavedAds
{
	public class SavedAdsDto
	{
		public long UserId { get; set; }
		public long AnnouncementId { get; set; }

		public static implicit operator SavedAd(SavedAdsDto ads)
		{
			return new SavedAd()
			{
				UserId = ads.UserId,
				AnnouncementId = ads.AnnouncementId,
			};
		}
	}
}
