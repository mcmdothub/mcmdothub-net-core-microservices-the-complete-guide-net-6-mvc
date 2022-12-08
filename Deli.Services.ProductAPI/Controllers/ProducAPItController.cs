using Deli.Services.ProductAPI.Models.Dto;
using Deli.Services.ProductAPI.Repository;

using Microsoft.AspNetCore.Mvc;

namespace Deli.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProducAPItController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProducAPItController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }

        // the response of Get will be generic of type "object" (could have been also of type ResponseDto)
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                // try to get an IEnumerable of ProductDto
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();

                // once we get the products we have to populate _response with "productDtos" that we have found
                _response.Result = productDtos;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        // on the Route we expect an id to be passed here
        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDto productDto = await _productRepository.GetProductById(id);
                _response.Result = productDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
