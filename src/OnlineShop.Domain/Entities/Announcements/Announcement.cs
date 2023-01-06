using OnlineShop.Domain.Entities.Categorys;
using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Domain.Entities.Announcements
{
    public class Announcement
    {
        public long Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public long CategorieId { get; set; }
        public virtual Categorie Categorie { get; set; } = null!;
        public string ImagePath { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public long UserId { get; set; }
        public virtual User User { get; set; } = default!;
        public DateTime CreateAt { get; set; }
        public long LiceCount { get; set; }
    }
}
