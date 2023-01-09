using OnlineShop.Domain.Entities.SavedAds;

namespace OnlineShop.Service.Dtos.SavedAds
{
    public class SavedAdsDto
    {
        public long UserId { get; set; }
        public long AnnouncementId { get; set; }

        public static implicit operator SaveAds(SavedAdsDto ads)
        {
            return new SaveAds()
            {
                UserId = ads.UserId,
                AnnouncementId = ads.AnnouncementId,
            };
        }
    }
}
