using Api.Core.DTOS;

namespace Api.Core.Interfaces
{
    public interface IProductService
    {
        //Will hold all the logic for product and return DTOS Like view Model
        //Get All Products
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();

        //Get All Brands
        Task<IEnumerable<BrandTypeDto>> GetAllBrandsAsync();

        Task<IEnumerable<BrandTypeDto>> GetAllTypesAsync();


        Task<ProductDTO> GetProductById(int id);
    }
}
