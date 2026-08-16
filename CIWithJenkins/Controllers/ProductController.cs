using CIWithJenkins.DTOs.Products;
using CIWithJenkins.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIWithJenkins.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<ProductDTO>>> GetAll()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }
        [HttpGet("{id:guid}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ProductDTO>> GetById(Guid id)
        {
            return Ok(await _productService.GetById(id));
        }
        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Update(Guid id, ProductDTO product)
        {
            await _productService.Update(id, product);
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _productService.Delete(id);
            return NoContent();
        }
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult> Create(ProductDTO product)
        {
            await _productService.Create(product);
            return Created();
        }
    }
}
