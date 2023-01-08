namespace OnlineShop.Service.Dtos.Category
{
    public class CategoryDto
    {
        public string Category { get; set; } = String.Empty;

        public static implicit operator OnlineShop.Domain.Entities.Categorys.Category(CategoryDto dto)
        {
            return new Domain.Entities.Categorys.Category()
            {
                Name = dto.Category
            };
        }
    }
}
