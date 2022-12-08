using Deli.Services.ProductAPI.Models.Dto;

namespace Deli.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        // Get All Products
        // Return type will be Task because we want it to be asynchronous
        // And will return an IEnumerable of ProductDto (we only work with DTO when we return or get something in an API)
        // after will convert that DTL to the product entity and then work with the database
        Task<IEnumerable<ProductDto>> GetProducts();

        Task<ProductDto> GetProductById(int productId);

        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);

        Task<bool> DeleteProduct(int productId);
    }
}
