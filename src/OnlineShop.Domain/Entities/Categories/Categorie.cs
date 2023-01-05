using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities.Categorys
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Filr  { get; set; } = String.Empty;
    }
}
