using AutoMapper;
using OnlineMenu.Core.Dtos;
using OnlineMenu.Core.IUnitOfWork;
using OnlineMenu.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service
{
    public class CategoryService : ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task AddAysnc(CategoryAddDto entity)
        {
            _unitOfWork.categoryRepository.AddAysnc()
        }

        public Task<bool> AnyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDto>> GetAllAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(CategoryUpdateDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
