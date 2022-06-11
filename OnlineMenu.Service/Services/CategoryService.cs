using AutoMapper;
using OnlineMenu.Core.Dtos;
using OnlineMenu.Core.Entities;
using OnlineMenu.Core.IUnitOfWork;
using OnlineMenu.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMenu.Service.Services
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

        public async Task AddAysnc(CategoryAddDto entity)
        {
            await _unitOfWork.categoryRepository.AddAysnc(_mapper.Map<Category>(entity));
            await _unitOfWork.SaveAsync();
        }

        public Task<bool> AnyAsync()
        {
            return _unitOfWork.categoryRepository.AnyAsync(null
                );
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.categoryRepository.CountAsync(null);
        }

        public async Task Delete(int id)
        {

            await _unitOfWork.categoryRepository.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync(int userId)
        {
            var categoryList = await _unitOfWork.categoryRepository.GetAllAsync(x => x.UserId == userId);
            return _mapper.Map<IEnumerable<CategoryDto>>(categoryList);
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _unitOfWork.categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task Update(CategoryUpdateDto entity)
        {
            await _unitOfWork.categoryRepository.Update(_mapper.Map<Category>(entity));
            await _unitOfWork.SaveAsync();
        }
    }
}
