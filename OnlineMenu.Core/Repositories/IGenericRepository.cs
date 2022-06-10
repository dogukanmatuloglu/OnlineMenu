using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync( Expression<Func<T, bool>> predicate = null,params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);
        Task AddAysnc(T entity);
        Task Update(T entity );
        Task Delete(int id);
        Task<bool> AnyAsync(Expression<Func<T,bool>> predicate);
        Task<int> CountAsync(Expression<Func<T,bool>> predicate);


    }
}
