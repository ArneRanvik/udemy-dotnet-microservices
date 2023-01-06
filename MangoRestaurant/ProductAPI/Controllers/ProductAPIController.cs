using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models.DTOs;
using ProductAPI.Repository;

namespace ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO<List<ProductDTO>>>> Get()
        {
            return Ok(await _productRepository.GetProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO<ProductDTO>>> Get(int id)
        {
            var response = await _productRepository.GetProductById(id);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO<ProductDTO>>> Post(ProductDTO product)
        {
            var response = await _productRepository.CreateUpdateProduct(product);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseDTO<ProductDTO>>> Put(ProductDTO product)
        {
            var response = await _productRepository.CreateUpdateProduct(product);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDTO<bool>>> Delete(int id)
        {
            var response = await _productRepository.DeleteProduct(id);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
