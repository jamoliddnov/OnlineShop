using OnlineShop.DataAccess.Interfaces.Common;

namespace OnlineShop.Domain.Entities
{
	public class Category : BaseEntity
	{
		public string CategoryName { get; set; } = string.Empty;
	}
}
