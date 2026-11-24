using api.DTOs;
using api.Models;
using api.Repository;

namespace api.Services
{
    public class RestaurantServices : IRestaurantServices
    {
        private readonly IRestaurantRepository _repository;

        public RestaurantServices(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RestaurantResponse>> GetAllAsync()
        {
            List<Restaurant> restaurants = await _repository.GetAllAsync();
            return restaurants.Select(ToDto).ToList();
        }

        public async Task<RestaurantResponse?> GetByIdAsync(int id)
        {
            Restaurant? restaurant = await _repository.GetByIdAsync(id);
            return restaurant is null ? null : ToDto(restaurant);
        }

        public async Task<RestaurantResponse> CreateAsync(CreateRestaurantRequest request)
        {
            Restaurant restaurant = new Restaurant
            {
                Name = request.Name,
                Tagline = request.Tagline,
                Address = request.Address,
                Hours = request.Hours,
                Phone = request.Phone
            };

            Restaurant created = await _repository.AddAsync(restaurant);
            return ToDto(created);
        }

        public async Task<RestaurantResponse?> UpdateAsync(int id, UpdateRestaurantRequest request)
        {
            Restaurant? restaurant = await _repository.GetByIdAsync(id);
            if (restaurant is null)
            {
                return null;
            }

            restaurant.Name = request.Name;
            restaurant.Tagline = request.Tagline;
            restaurant.Address = request.Address;
            restaurant.Hours = request.Hours;
            restaurant.Phone = request.Phone;

            await _repository.UpdateAsync(restaurant);
            return ToDto(restaurant);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Restaurant? restaurant = await _repository.GetByIdAsync(id);
            if (restaurant is null)
            {
                return false;
            }

            await _repository.DeleteAsync(restaurant);
            return true;
        }

        private static RestaurantResponse ToDto(Restaurant restaurant)
        {
            return new RestaurantResponse
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Tagline = restaurant.Tagline,
                Address = restaurant.Address,
                Hours = restaurant.Hours,
                Phone = restaurant.Phone
            };
        }
    }
}
