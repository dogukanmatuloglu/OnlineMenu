using AutoMapper;
using OnlineMenu.Core.Dtos;
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

        public Task AddAysnc(ProductAddDto entity)
        {
            throw new NotImplementedException();
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

        public Task<IEnumerable<ProductDto>> GetAllAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductUpdateDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
