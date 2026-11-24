using api.Models;

namespace api.Repository;

public interface ICategoriesRepository
{
    Task<List<Categories>> GetAllAsync();
    Task<Categories?> GetByIdAsync(int id);
    Task<Categories> AddAsync(Categories category);
    Task UpdateAsync(Categories category);
    Task DeleteAsync(Categories category);
}
