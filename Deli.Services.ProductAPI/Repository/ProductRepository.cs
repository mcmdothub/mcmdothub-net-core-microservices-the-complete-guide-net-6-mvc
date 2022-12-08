using AutoMapper;

using Deli.Services.ProductAPI.DbContexts;
using Deli.Services.ProductAPI.Models;
using Deli.Services.ProductAPI.Models.Dto;

using Microsoft.EntityFrameworkCore;

namespace Deli.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        // Dependency injection our DbContext & automapper
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            // this is a type of Product 
            List<Product> productList = await _db.Products.ToListAsync();

            // need to return an IEnumerable<ProductDto>
            return _mapper.Map<List<ProductDto>>(productList);
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            // we use auto mapper map and convert a product DTA to a product model
            Product product = _mapper.Map<ProductDto, Product>(productDto);

            // verify if this is an update or create
            if (product.ProductId > 0)
            {
                // means the product was allready created, so we just update the product model
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }

            await _db.SaveChangesAsync();

            // we want to convert a product to product DTO and will pass inside a product
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                // we retrieve the product we want to delete
                Product product = await _db.Products.FirstOrDefaultAsync(u => u.ProductId == productId);

                // if we cannot find the product
                if (product == null)
                {
                    return false;
                }

                _db.Products.Remove(product);

                await _db.SaveChangesAsync();
                // if success will return true
                return true;
            }
            catch (Exception)
            {
                // because the deletion was not successful will return false
                return false;
            }
        }
    }
}
