using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext _db;

        public RestaurantRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Restaurant>> GetAllAsync()
        {
            return await _db.Restaurant.ToListAsync();
        }

        public async Task<Restaurant?> GetByIdAsync(int id)
        {
            return await _db.Restaurant.FindAsync(id);
        }

        public async Task<Restaurant> AddAsync(Restaurant restaurant)
        {
            _db.Restaurant.Add(restaurant);
            await _db.SaveChangesAsync();
            return restaurant;
        }

        public async Task UpdateAsync(Restaurant restaurant)
        {
            _db.Restaurant.Update(restaurant);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Restaurant restaurant)
        {
            _db.Restaurant.Remove(restaurant);
            await _db.SaveChangesAsync();
        }
    }
}
