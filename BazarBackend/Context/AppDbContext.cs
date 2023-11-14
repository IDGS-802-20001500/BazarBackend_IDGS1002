using Microsoft.EntityFrameworkCore;
using BazarBackend.Model;

namespace BazarBackend.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Productos> Productos { get; set; }
    }
}
