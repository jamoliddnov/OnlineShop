using OnlineShop.DataAccess.Interfaces.Common;

namespace OnlineShop.Domain.Entities
{
	public class Announcement : BaseEntity
	{
		public string Title { get; set; } = string.Empty;
		public long CategoryId { get; set; }
		public virtual Category Category { get; set; } = default!;
		public string ImagePath { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public double Price { get; set; }
		public string PhoneNumber { get; set; } = string.Empty;
		public long UserId { get; set; }
		public virtual User User { get; set; } = default!;
		public string CreateAt { get; set; }
		public long LiceCount { get; set; }
	}
}
