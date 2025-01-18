using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RMP.Host.Entities.Identity;

public class UserEntity : IdentityUser<int>
{
    public required string Name { get; set; }
    
    public required string Surname { get; set; }
    
    public required Guid UniversityId { get; set; }
    
    public required Guid DepartmentId { get; set; }
    
    public int? Grade { get; set; }
    
    public string? ProfilePhotoPath { get; set; }
    
    public virtual UniversityEntity? University { get; set; }
    
    public DepartmentEntity? Department { get; set; }
    
    public RateUniversityEntity? RateUniversity { get; set; }

    public ICollection<RateProfessorEntity>? RateProfessors { get; set; }
}

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");

        builder.HasOne(x => x.University)
            .WithMany()
            .HasForeignKey(x => x.UniversityId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}