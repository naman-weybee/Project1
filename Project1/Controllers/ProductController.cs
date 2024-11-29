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
        //public async Task<IActionResult> GetAllProducts([FromQuery] RequestParams requestParams)
        //{
        //    var response = new ResponseStructure();
        //    try
        //    {
        //        var data = await _productService.GetAllProductsAsync(requestParams);
        //        return Ok(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.error = ex.Message;
        //        return StatusCode(500, response);
        //    }
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return StatusCode(200, product);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDTO productDTO)
        {
            await _productService.CreateProductAsync(productDTO);
            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromForm] ProductDTO productDTO)
        {
            await _productService.UpdateProductAsync(productDTO);
            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct([FromRoute] int id)
        {
            _productService.DeleteProductAsync(id);
        }
    }
}