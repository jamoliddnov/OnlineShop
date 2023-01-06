using OnlineShop.Domain.Entities.Announcements;
using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Domain.Entities.SavedAds
{
    public class SaveAds
    {
        public long Id { get; set; }
        public long AnnouncementId { get; set; }
        public virtual Announcement Announcement { get; set; } = default!;
        public long UserId { get; set; }
        public virtual User User { get; set; } = default!;

    }
}
