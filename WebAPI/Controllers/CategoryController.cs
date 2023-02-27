using Business.Abstracts;
using Entities.Dtos.Requests.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
        {
            try
            {
                var result = await _service.AddCategories(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("delete")]
        public async Task<IActionResult> DeleteCategory([FromQuery] int id)
        {
            try
            {
                var request = new CategoryIdRequest { Id = id };
                await _service.DeleteCategory(request);
                return Ok();
            }
            catch (Exception e)  
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request)
        {
            try
            {
                var result = await _service.UpdateCategory(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getallcategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var result = await _service.GetAllCategories();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("gettcategorybyid")]
        public async Task<IActionResult> GetCategoryById([FromQuery] int id)
        {
            try
            {
                var request = new CategoryIdRequest { Id = id };
                var result = await _service.GetCategoryById(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getactivecategories")]
        public async Task<IActionResult> GetActiveCtegories()
        {
            try
            {
                var result = await _service.GetCategoriesByIsActiveAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getsubcategoriesbycategoryid")]
        public async Task<IActionResult> GetSubCategoriesByCategoryId([FromQuery] int id)
        {
            try
            {
                var request = new CategoryIdRequest { Id = id };
                var result = await _service.GetSubCategoriesByCategoryIdAsync(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getparentcategorybycategoryid")]
        public async Task<IActionResult> GetParentCategoryByCategoryId([FromQuery] int id)
        {
            try
            {
                var request = new CategoryIdRequest { Id = id };
                var result = await _service.GetParentCategoryByCategoryIdAsync(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
