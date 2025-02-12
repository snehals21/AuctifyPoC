using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<IdeaEntity> Ideas { get; set; } 
    }
}
