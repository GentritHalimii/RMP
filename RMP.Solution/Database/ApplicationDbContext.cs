using Microsoft.EntityFrameworkCore;
using RMP.Host.Entities;

namespace RMP.Host.Database;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<UniversityEntity> Universities { get; set; }
    public DbSet<DepartmentEntity> Departments { get; set; }
    public DbSet<ProfessorEntity> Professors { get; set; }
    
}
