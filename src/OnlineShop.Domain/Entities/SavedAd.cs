using OnlineShop.DataAccess.Interfaces.Common;

namespace OnlineShop.Domain.Entities
{
    public class SavedAd : BaseEntity
    {
        public long AnnouncementId { get; set; }
        public virtual Announcement Announcement { get; set; } = default!;
        public long UserId { get; set; }
        public virtual User User { get; set; } = default!;

    }
}
