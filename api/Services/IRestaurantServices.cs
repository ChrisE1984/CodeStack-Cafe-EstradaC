using api.DTOs;

namespace api.Services;

public interface IRestaurantServices
{
    Task<List<RestaurantResponse>> GetAllAsync();
    Task<RestaurantResponse?> GetByIdAsync(int id);
    Task<RestaurantResponse> CreateAsync(CreateRestaurantRequest request);
    Task<RestaurantResponse?> UpdateAsync(int id, UpdateRestaurantRequest request);
    Task<bool> DeleteAsync(int id);
}
