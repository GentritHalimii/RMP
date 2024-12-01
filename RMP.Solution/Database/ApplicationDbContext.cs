using Microsoft.EntityFrameworkCore;
using RMP.Host.Entities;

namespace RMP.Host.Database;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<UniversityEntity> Universities { get; set; }
}
