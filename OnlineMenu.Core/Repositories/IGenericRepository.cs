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
        Task<IEnumerable<T>> GetAllAsync(int userId, Expression<Func<T, bool>> predicate = null,params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id,int userId);
        Task AddAysnc(T entity, int userId);
        Task Update(T entity, int userId);
        Task Delete(int id, int userId);
        Task<bool> AnyAsync(Expression<Func<T,bool>> predicate, int userId);
        Task<int> CountAsync(Expression<Func<T,bool>> predicate, int userId);


    }
}
