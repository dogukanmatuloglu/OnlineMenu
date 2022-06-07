using OnlineMenu.Core.Entities;
using OnlineMenu.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Data.Repositories
{
    internal class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(OnlineMenuContext context) : base(context)
        {
        }
    }
}
