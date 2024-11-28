using Microsoft.AspNetCore.Mvc;
using Project1.DTOs;
using Project1.Services;

namespace Project1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return StatusCode(200, products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return StatusCode(200, product);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDTO productDTO)
        {
            var product = await _productService.CreateProductAsync(productDTO);
            return StatusCode(201, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromForm] UpdateProductDTO productDTO)
        {
            var product = await _productService.UpdateProductAsync(id, productDTO);
            return StatusCode(200, product);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct([FromRoute] int id)
        {
            _productService.DeleteProductAsync(id);
        }
    }
}