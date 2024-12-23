using RMP.Host.Entities.Identity;

namespace RMP.Host.Entities;

public class DepartmentEntity : BaseEntity
{
    /// <summary>
    /// Name of the department.
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// Foreign key from University
    /// </summary>
    public Guid UniversityId { get; set; }

    /// <summary>
    /// Year the department was established.
    /// </summary>
    public required int EstablishedYear { get; set; }

    /// <summary>
    /// Brief description of the department.
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
    /// The user associated with the department.
    /// </summary>
    public ICollection<UserEntity> Users { get; set; }
    
    /// <summary>
    /// The university associated with the department.
    /// </summary>
    public UniversityEntity University { get; set; }
}