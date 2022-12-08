using Deli.Web.Models;

namespace Deli.Web.Services.IServices
{
    // here we will have all of the methods to do crude operations on product
    public interface IProductService : IBaseService
    {
        // we keep the Task generic as T 
        Task<T> GetAllProductsAsync<T>();

        Task<T> GetProductByIdAsync<T>(int id);

        Task<T> CreateProductAsync<T>(ProductDto productDto);

        Task<T> UpdateProductAsync<T>(ProductDto productDto);

        Task<T> DeleteProductAsync<T>(int id);
    }
}
