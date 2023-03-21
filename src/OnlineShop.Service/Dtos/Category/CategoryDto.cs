using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Service.Dtos.Category
{
	public class CategoryDto
	{
		[Required, MaxLength(1), MinLength(1)]
		public string Category { get; set; } = String.Empty;

		public static implicit operator Domain.Entities.Category(CategoryDto dto)
		{
			return new Domain.Entities.Category()
			{
				CategoryName = dto.Category
			};
		}
	}
}
