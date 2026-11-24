using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Menu> Menu { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}