using OnlineShop.DataAccess.Interfaces.Common;

namespace OnlineShop.Domain.Entities.Categorys
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string Filr { get; set; } = String.Empty;
    }
}
