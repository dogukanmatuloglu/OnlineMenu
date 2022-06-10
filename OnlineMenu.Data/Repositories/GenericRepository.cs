using Microsoft.EntityFrameworkCore;
using OnlineMenu.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Data.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly OnlineMenuContext _context;
        public GenericRepository(OnlineMenuContext context)
        {
            _context = context;
        }

        public async Task AddAysnc(T entity)
        {
          await  _context.Set<T>().AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
          return  await _context.Set<T>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate=null)
        {
            return  await _context.Set<T>().CountAsync(predicate);
        }

        public async Task Delete(int id)
        {
           var deletedEntity=  await _context.Set<T>().FindAsync(id);
            await Task.Run( ()=> { _context.Set<T>().Remove(deletedEntity); });
            //_context.Set<T>().Remove(deletedEntity);
        }

        public async Task<IEnumerable<T>> GetAllAsync( Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate!=null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
             await Task.Run(() => { _context.Set<T>().Update(entity); });
        }
    }
}
