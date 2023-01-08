using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces.Categories;

namespace OnlineShop.DataAccess.Repositories.Categorie
{
    public class CategoriesRepositorie : GenericRepository<OnlineShop.Domain.Entities.Categorys.Category>, ICategoryRepositorie
    {
        public CategoriesRepositorie(AppDbContext context)
            : base(context)
        {
        }
    }
}
