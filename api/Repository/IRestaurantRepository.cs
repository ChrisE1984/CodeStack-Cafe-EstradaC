using api.Models;

namespace api.Repository;

public interface IRestaurantRepository
{
    Task<List<Restaurant>> GetAllAsync();
    Task<Restaurant?> GetByIdAsync(int id);
    Task<Restaurant> AddAsync(Restaurant restaurant);
    Task UpdateAsync(Restaurant restaurant);
    Task DeleteAsync(Restaurant restaurant);
}
