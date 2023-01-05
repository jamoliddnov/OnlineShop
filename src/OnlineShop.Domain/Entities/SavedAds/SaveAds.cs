using OnlineShop.Domain.Entities.Announcements;
using OnlineShop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
