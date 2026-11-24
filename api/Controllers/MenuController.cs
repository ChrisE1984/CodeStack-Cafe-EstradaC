using api.DTOs;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuServices _services;
        public MenuController (IMenuServices services)
        {
            _services = services;
        }

        [HttpGet("restaurant")]
        public ActionResult<object> GetRestaurant()
        {
            return Ok(new
            {
                name = "CodeStack Café",
                tagline = "fuel for your next commit",
                address = "Room 101 · Main Campus",
                hours = "Mon–Fri · 8am–5pm",
                phone = "(555) 010-1010"
            });
        }

        [HttpGet]
        public async Task<ActionResult<List<MenuResponseDTO>>> GetAll()
        {
            return Ok(await _services.GetAllAsync());
        }

        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<MenuResponseDTO>> GetById(int id)
        {
            MenuResponseDTO? menu = await _services.GetByIDAsync(id);

            if(menu is null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        [HttpPost("AddItem")]
        public async Task<ActionResult<MenuResponseDTO>> AddItem([FromBody] CreateMenuDTO dto)
        {
            MenuResponseDTO menu = await _services.CreateAsync(dto);
            return CreatedAtAction (nameof (GetById), new {id = menu.Id}, menu);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<MenuResponseDTO>> Update(int id, UpdateMenuDTO dto)
        {
            MenuResponseDTO menu = await _services.UpdateAsync(id,dto);
            if(menu is null)
            {
                return NotFound();
            }

            return Ok(menu);
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