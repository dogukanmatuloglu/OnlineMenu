using OnlineMenu.Core.IUnitOfWork;
using OnlineMenu.Core.Repositories;
using OnlineMenu.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineMenuContext _context;

        public UnitOfWork(OnlineMenuContext context)
        {
            _context = context;
        }
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;



        public IProductRepository productRepository => _productRepository ??= new ProductRepository(_context);

        public ICategoryRepository categoryRepository => _categoryRepository ??=new CategoryRepository(_context);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
