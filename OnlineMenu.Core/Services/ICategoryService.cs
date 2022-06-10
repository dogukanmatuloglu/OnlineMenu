using OnlineMenu.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Core.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync(int userId);
        Task<CategoryDto> GetByIdAsync(int id);
        Task AddAysnc(CategoryAddDto entity);
        Task Update(CategoryUpdateDto entity);
        Task Delete(int id);
        Task<bool> AnyAsync();
        Task<int> CountAsync();
    }
}
