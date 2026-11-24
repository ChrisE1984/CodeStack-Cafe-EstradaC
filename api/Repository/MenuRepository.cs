using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class MenuRepository : IMenuRepository
    {

        private readonly AppDbContext _db;

        //DI: we never write a "new AppDbContext()" ourselves
        //ASP.NET Core sees this constructor, asks for one and passes it for us
        public MenuRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<Menu>> GetAllAsync()
        {
            return await _db.Menu.ToListAsync();
        }

        public async Task<Menu?> GetByIdAsync(int id)
        {
            return await _db.Menu.FindAsync(id);
        }
        public async Task<Menu> AddAsync(Menu menu)
        {
           _db.Menu.Add(menu);
            await _db.SaveChangesAsync();
            return menu;
        }

        public async Task UpdateAsync(Menu menu)
        {
            _db.Menu.Update(menu);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteAsync(Menu menu)
        {
            _db.Menu.Remove(menu);
            await _db.SaveChangesAsync();
        }


    }
}