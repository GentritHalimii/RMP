using RMP.Host.Entities.Identity;

namespace RMP.Host.Entities;

public class UniversityEntity : BaseEntity
{
    /// <summary>
    /// Name of the university.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Year the university was established.
    /// </summary>
    public required int EstablishedYear { get; set; }

    /// <summary>
    /// Brief description of the university.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Total number of staff members.
    /// </summary>
    public int StaffNumber { get; set; }

    /// <summary>
    /// Total number of students enrolled.
    /// </summary>
    public int StudentsNumber { get; set; }

    /// <summary>
    /// Total number of courses offered.
    /// </summary>
    public int CoursesNumber { get; set; }

    /// <summary>
    /// Path to the university's profile photo (optional).
    /// </summary>
    public string? ProfilePhotoPath { get; set; }
    
    /// <summary>
    /// The department associated with the university.
    /// </summary>
    public ICollection<DepartmentEntity> Departments { get; set; }
    
    /// <summary>
    /// The user associated with the university.
    /// </summary>
    public ICollection<UserEntity> Users { get; set; }
}