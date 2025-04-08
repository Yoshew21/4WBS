using Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance;

public class AppDbContext : DbContext
{
    public DbSet<Library> Libraries { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
}