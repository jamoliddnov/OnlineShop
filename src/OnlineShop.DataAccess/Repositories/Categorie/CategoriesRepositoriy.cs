using OnlineShop.DataAccess.DbContexts;
using OnlineShop.DataAccess.Interfaces.Categories;
using OnlineShop.Domain.Entities.Categorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess.Repositories.Categorie
{
    public class CategoriesRepositorie : GenericRepository<OnlineShop.Domain.Entities.Categorys.Categorie>, ICategoryRepositorie 
    {
        public CategoriesRepositorie(AppDbContext context) 
            : base(context)
        {
        }
    }
}
