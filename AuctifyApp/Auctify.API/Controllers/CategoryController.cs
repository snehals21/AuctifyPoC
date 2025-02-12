using Application.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Auctify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // This class will be used to handle the request and reponse of the API.

        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryEntity categoryEntity)
        {
            var result = await _categoryService.CreateCategory(categoryEntity);
            return Ok(result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryEntity categoryEntity)
        {
            var record = await _categoryService.UpdateCategory(id, categoryEntity);
            return Ok(record);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {

            var deleted_record = await _categoryService.DeleteCategory(id);
            return Ok(deleted_record);
        }

    }
}
