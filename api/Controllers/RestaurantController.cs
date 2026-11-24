using api.DTOs;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantServices _services;

        public RestaurantController(IRestaurantServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<RestaurantResponse>>> GetAll()
        {
            return Ok(await _services.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RestaurantResponse>> GetById(int id)
        {
            RestaurantResponse? restaurant = await _services.GetByIdAsync(id);
            if (restaurant is null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

       [HttpPost("AddInfo")]
        public async Task<ActionResult<RestaurantResponse>> Create([FromBody] CreateRestaurantRequest request)
        {
            RestaurantResponse restaurant = await _services.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = restaurant.Id }, restaurant);
        }

         [HttpPut("Update/{id}")]
        public async Task<ActionResult<RestaurantResponse>> Update(int id, [FromBody] UpdateRestaurantRequest request)
        {
            RestaurantResponse? restaurant = await _services.UpdateAsync(id, request);
            if (restaurant is null)
            {
                return NotFound();
            }

            return Ok(restaurant);
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
