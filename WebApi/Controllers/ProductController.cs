using Api.Core.DTOS;
using Api.Core.Interfaces;
using Api.Core.Models;
using Api.Core.Specifications;
using Api.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    public class ProductController : BaseApiController
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> ShowAll() 
        {
           var productsToDisplay =  await _service.GetAllProductsAsync();

            if(productsToDisplay is not null) 
            {
                return productsToDisplay;
            }
            else 
            {
                return new List<ProductDTO>();
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GeyById(int id)
        {
            return await _service.GetProductById(id);
        }
    }
}
