using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RMP.Host.Entities;
using RMP.Host.Entities.Identity;

namespace RMP.Host.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<UserEntity, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>(options)
{
    public DbSet<UniversityEntity> Universities { get; set; }
    public DbSet<DepartmentEntity> Departments { get; set; }
    public DbSet<ProfessorEntity> Professors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration.RoleSeedData());
        modelBuilder.Entity<UserRole>().ToTable("UserRoles");
        modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims");
        modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
        modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
        modelBuilder.Entity<UserToken>().ToTable("UserTokens");
        modelBuilder.Entity<UniversityEntity>().ToTable("Universities");
        modelBuilder.Entity<DepartmentEntity>().ToTable("Departments");
        modelBuilder.Entity<ProfessorEntity>().ToTable("Professors");
        
        modelBuilder.Entity<UniversityEntity>()
            .HasKey(pk => new { pk.Id });
        modelBuilder.Entity<DepartmentEntity>()
            .HasKey(pk => new { pk.Id });
        modelBuilder.Entity<ProfessorEntity>()
            .HasKey(pk => new { pk.Id });
        
        /// === UniversityEntity === ///
        modelBuilder.Entity<UniversityEntity>()
            .HasMany(u => u.Departments)
            .WithOne(d => d.University)
            .HasForeignKey(d => d.UniversityId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // === UserEntity Relationships === //
        modelBuilder.Entity<UserEntity>()
            .HasOne(u => u.University)
            .WithMany()
            .HasForeignKey(u => u.UniversityId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserEntity>()
            .HasOne(u => u.Department)
            .WithMany(d => d.Users)
            .HasForeignKey(u => u.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // === DepartmentEntity === //
        modelBuilder.Entity<DepartmentEntity>()
            .HasOne(d => d.University)
            .WithMany(u => u.Departments)
            .HasForeignKey(d => d.UniversityId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
