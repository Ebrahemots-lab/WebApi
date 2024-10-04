using Api.Core.Interfaces;
using Api.Core.Models;
using Api.Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    public class ProductController : BaseApiController
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> ShowAll() 
        {
            var specs = new BaseSpecifications<Product>();

            specs.Includes.Add(P => P.Brand);
            specs.Includes.Add(P => P.Type);

            var result = await _repo.GetAllAsyncSpec(specs);

            return Ok(result);
        }
    }
}
