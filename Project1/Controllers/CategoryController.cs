using Microsoft.AspNetCore.Mvc;
using Project1.DTOs;
using Project1.RequestModel;
using Project1.ResponseModel;
using Project1.Services;

namespace Project1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService service, ILogger<CategoryController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery] RequestParams requestParams)
        {
            var response = new ResponseStructure();

            try
            {
                var data = await _service.GetAllCategoriesAsync(requestParams);
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

        [HttpGet("Tree")]
        public async Task<IActionResult> GetCategoryTree()
        {
            var response = new ResponseStructure();

            try
            {
                var data = await _service.GetCategoryTreeAsync();
                if (data != null)
                {
                    response.data = new ResponseTreeMetadata<object>()
                    {
                        records = data
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
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var response = new ResponseStructure();

            try
            {
                var data = await _service.GetCategoryByIdAsync(id);
                if (data != null)
                {
                    response.data = data;
                    response.success = true;
                    return StatusCode(200, data);
                }

                response.error = $"Requested Category for Id = {id} is Not Found...!";
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
        public async Task<IActionResult> CreateCategory([FromForm] CreateCategoryDTO _dto)
        {
            var response = new ResponseStructure();

            try
            {
                await _service.CreateCategoryAsync(_dto);
                response.data = new { Message = "New Category Added Successfully...!" };
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
        public async Task<IActionResult> UpdateCategory([FromForm] CategoryDTO _dto)
        {
            var response = new ResponseStructure();

            try
            {
                await _service.UpdateCategoryAsync(_dto);
                response.data = new { Message = "Category Modified Successfully...!" };
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
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var response = new ResponseStructure();

            try
            {
                await _service.DeleteCategoryAsync(id);
                response.data = new { Message = $"Category with Id = {id} is Deleted Successfully...!" };
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