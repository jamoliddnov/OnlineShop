namespace OnlineShop.Service.Dtos.Category
{
    public class CategoryDto
    {
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
