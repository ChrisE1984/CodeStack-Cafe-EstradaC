
using api.Models;

namespace api.Repository
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllAsync();
        Task <Menu?> GetByIdAsync(int id);
        Task <Menu> AddAsync(Menu menu);
        Task UpdateAsync(Menu menu);
        Task DeleteAsync(Menu menu);
        
    }
}