using Microsoft.AspNetCore.Mvc;
using Project1.DTOs;
using Project1.RequestModel;
using Project1.ResponseModel;
using Project1.Services;

namespace Project1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _service;
        private readonly ILogger<ProductCategoryController> _logger;

        public ProductCategoryController(IProductCategoryService service, ILogger<ProductCategoryController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductCategories([FromQuery] RequestParams requestParams)
        {
            var response = new ResponseStructure();

            try
            {
                var data = await _service.GetAllProductCategoriesAsync(requestParams);
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

        [HttpGet("Detailed")]
        public async Task<IActionResult> GetAllDetailedProductCategories([FromQuery] RequestParams requestParams)
        {
            var response = new ResponseStructure();

            try
            {
                var data = await _service.GetAllDetailedProductCategoriesAsync(requestParams);
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

        [HttpGet("{id1}/{id2}")]
        public async Task<IActionResult> GetProductCategoryById([FromRoute] int id1, int id2)
        {
            var response = new ResponseStructure();

            try
            {
                var data = await _service.GetProductCategoryByIdAsync(id1, id2);
                if (data != null)
                {
                    response.data = data;
                    response.success = true;
                    return StatusCode(200, data);
                }

                response.error = $"Requested Product-Category for Ids = {id1}, {id2} is Not Found...!";
                return NotFound(response);
            }
            catch (Exception ex)
            {
                response.error = ex.Message;
                _logger.LogError(ex.Message);

                return StatusCode(500, response);
            }
        }

        [HttpGet("Detailed/{id1}/{id2}")]
        public async Task<IActionResult> GetDetailedProductCategoryById([FromRoute] int id1, int id2)
        {
            var response = new ResponseStructure();

            try
            {
                var data = await _service.GetDetailedProductCategoryByIdAsync(id1, id2);
                if (data != null)
                {
                    response.data = data;
                    response.success = true;
                    return StatusCode(200, data);
                }

                response.error = $"Requested Product-Category for Ids = {id1}, {id2} is Not Found...!";
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
        public async Task<IActionResult> CreateProductCategory([FromForm] ProductCategoryDTO _dto)
        {
            var response = new ResponseStructure();

            try
            {
                await _service.CreateProductCategoryAsync(_dto);
                response.data = new { Message = "New Product-Category Added Successfully...!" };
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

        [HttpPut("{id1}/{id2}")]
        public async Task<IActionResult> UpdateProductCategory([FromRoute] int id1, [FromRoute] int id2, [FromForm] ProductCategoryDTO _dto)
        {
            var response = new ResponseStructure();

            try
            {
                await _service.UpdateProductCategoryAsync(id1, id2, _dto);
                response.data = new { Message = "Product-Category Modified Successfully...!" };
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

        [HttpDelete("{id1}/{id2}")]
        public async Task<IActionResult> DeleteProductCategory([FromRoute] int id1, [FromRoute] int id2)
        {
            var response = new ResponseStructure();

            try
            {
                await _service.DeleteProductCategoryAsync(id1, id2);
                response.data = new { Message = $"Product-Category with ProductId = {id1} and CategoryId = {id2} is Deleted Successfully...!" };
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