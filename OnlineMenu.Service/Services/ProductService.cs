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
    public class ProductService : IProductService
    {

        private IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAysnc(ProductAddDto entity)
        {
            await _unitOfWork.productRepository.AddAysnc(_mapper.Map<Product>(entity));
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> AnyAsync()
        {
           return await _unitOfWork.productRepository.AnyAsync(null);
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.productRepository.CountAsync(null);
        }

        public async Task Delete(int id)
        {
           await _unitOfWork.productRepository.Delete(id);
            await _unitOfWork.SaveAsync();  
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync(int userId)
        {
           var productList=await _unitOfWork.productRepository.GetAllAsync(x=>x.UserId==userId);
            return _mapper.Map<IEnumerable<ProductDto>>(productList);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product=await _unitOfWork.productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task Update(ProductUpdateDto entity)
        {
            await _unitOfWork.productRepository.Update(_mapper.Map<Product>(entity));
            await _unitOfWork.SaveAsync();
        }
    }
}
