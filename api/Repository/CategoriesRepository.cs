using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext _db;

        public CategoriesRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Categories>> GetAllAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Categories?> GetByIdAsync(int id)
        {
            return await _db.Categories.FindAsync(id);
        }

        public async Task<Categories> AddAsync(Categories category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task UpdateAsync(Categories category)
        {
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Categories category)
        {
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
        }
    }
}
