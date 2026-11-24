using api.DTOs;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesServices _services;

        public CategoriesController(ICategoriesServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryResponse>>> GetAll()
        {
            return Ok(await _services.GetAllAsync());
        }

        [HttpGet("GetbyID/{id}")]
        public async Task<ActionResult<CategoryResponse>> GetById(int id)
        {
            CategoryResponse? category = await _services.GetByIdAsync(id);
            if (category is null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost("AddInfo")]
        public async Task<ActionResult<CategoryResponse>> Create([FromBody] CreateCategoryRequest request)
        {
            CategoryResponse category = await _services.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<CategoryResponse>> Update(int id, [FromBody] UpdateCategoryRequest request)
        {
            CategoryResponse? category = await _services.UpdateAsync(id, request);
            if (category is null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _services.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
