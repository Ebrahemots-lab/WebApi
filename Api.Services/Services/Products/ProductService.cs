using Api.Core.DTOS;
using Api.Core.Interfaces;
using Api.Core.Models;
using Api.Core.Specifications;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork uow , IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var specs = new ProductSpecifications();
            var result = await _uow.ProductRepository.GetAllAsyncSpec(specs);
            var mappedProducts = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(result);
            return mappedProducts;
        }

        public Task<IEnumerable<BrandTypeDto>> GetAllTypesAsync()
        {
            throw new NotImplementedException();
        }

     

        public Task<IEnumerable<BrandTypeDto>> GetAllBrandsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
                var specs = new ProductSpecifications(P => P.Id == id);
                var product = await _uow.ProductRepository.GetByIdAsyncSpec(specs);
                var mappedProduct = _mapper.Map<Product, ProductDTO>(product);
                return mappedProduct;
        }
    }


 

      

     

     
}
