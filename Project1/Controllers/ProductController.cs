using Microsoft.AspNetCore.Mvc;
using Project1.DTOs;
using Project1.RequestModel;
using Project1.ResponseModel;
using Project1.Services;

namespace Project1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] RequestParams requestParams)
        {
            var response = new ResponseStructure();

            try
            {
                var data = await _productService.GetAllProductsAsync(requestParams);
                if (data != null)
                {
                    response.data = new ResponseMetadata<object>()
                    {
                        page_number = requestParams.pageNumber,
                        page_size = requestParams.pageSize,
                        records = data,
                        total_records_count = requestParams.recordCount
                    };

                    response.success = true;
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                _logger.LogError(ex.Message);

                return StatusCode(500, response);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var response = new ResponseStructure();

            try
            {
                var data = await _productService.GetProductByIdAsync(id);
                if (data != null)
                {
                    response.data = data;
                    response.success = true;
                    return StatusCode(200, data);
                }

                response.error = $"Requested Product for Id = {id} is Not Found...!";
                return NotFound(response);
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                _logger.LogError(ex.Message);

                return StatusCode(500, response);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDTO productDTO)
        {
            var response = new ResponseStructure();

            try
            {
                await _productService.CreateProductAsync(productDTO);
                response.data = new { Message = "New Product Added Successfully...!" };
                response.success = true;
                return StatusCode(201, response);
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                _logger.LogError(ex.Message);

                return StatusCode(500, response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromForm] ProductDTO productDTO)
        {
            var response = new ResponseStructure();

            try
            {
                await _productService.UpdateProductAsync(productDTO);
                response.data = new { Message = "Product Modified Successfully...!" };
                response.success = true;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                _logger.LogError(ex.Message);

                return StatusCode(500, response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var response = new ResponseStructure();

            try
            {
                await _productService.DeleteProductAsync(id);
                response.data = new { Message = $"Product with Id = {id} is Deleted Successfully...!" };
                response.success = true;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                _logger.LogError(ex.Message);

                return StatusCode(500, response);
            }
        }
    }
}